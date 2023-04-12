using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SAM.Application.Commons.Bases;
using SAM.Application.DTOS.Request;
using SAM.Application.Interfaces;
using SAM.Domain.Entities;
using SAM.Infrastructure.Persistences.Interfaces;
using SAM.Utilities.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace SAM.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<BaseResponse<bool>> CreateUser(UserRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var account = _mapper.Map<User>(requestDTO);

            //Hashing password
            account.Password = BC.HashPassword(account.Password);
            response.Data = await _unitOfWork.User.CreateUser(account);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_INSERT;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR;
            }
            return response;
        }

        public async Task<BaseResponse<string>> GenerateToken(TokenRequestDTO requestDTO)
        {
            var response = new BaseResponse<string>();
            var account = await _unitOfWork.User.UserByEmail(requestDTO.Email!);
            if (account is not null)
            {
                if (BC.Verify(requestDTO.Password, account.Password))
                {
                    response.IsSuccess = true;
                    response.Data = GenerateToken(account);
                    response.Message = ReplyMessage.MESSAGE_TOKEN;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_WRONG_PASSWORD;
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR;
            }
            return response;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName!),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"])),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
