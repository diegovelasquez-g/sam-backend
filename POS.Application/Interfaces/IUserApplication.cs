using SAM.Application.Commons.Bases;
using SAM.Application.DTOS.Request;

namespace SAM.Application.Interfaces
{
    public interface IUserApplication
    {

        Task<BaseResponse<bool>> CreateUser(UserRequestDTO requestDTO);
        Task<BaseResponse<string>> GenerateToken(TokenRequestDTO requestDTO);
    }
}
