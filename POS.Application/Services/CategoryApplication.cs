using AutoMapper;
using SAM.Application.Commons.Bases;
using SAM.Application.DTOS.Request;
using SAM.Application.DTOS.Response;
using SAM.Application.Interfaces;
using SAM.Application.Validators.Category;
using SAM.Domain.Entities;
using SAM.Infrastructure.Persistences.Interfaces;
using SAM.Utilities.Static;

namespace SAM.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CategoryValidator _validator;

        public CategoryApplication(IUnitOfWork unitOfWork, IMapper mapper, CategoryValidator validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<IEnumerable<CategorySelectResponseDTO>>> ListSelectCategories()
        {
            var response = new BaseResponse<IEnumerable<CategorySelectResponseDTO>>();
            var categories = await _unitOfWork.Category.ListSelectCategories();
            if (categories is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<CategorySelectResponseDTO>>(categories);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<CategorySelectResponseDTO>>> ListSelectAllCategories()
        {
            var response = new BaseResponse<IEnumerable<CategorySelectResponseDTO>>();
            var categories = await _unitOfWork.Category.ListSelectAllCategories();
            if (categories is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<CategorySelectResponseDTO>>(categories);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<CategoryResponseDTO>> CategoryById(int categoryId)
        {
            var response = new BaseResponse<CategoryResponseDTO>();
            var category = await _unitOfWork.Category.CategoryById(categoryId);
            if (category is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<CategoryResponseDTO>(category);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> CreateCategory(CategoryRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validator.ValidateAsync(requestDTO);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }
            var category = _mapper.Map<Category>(requestDTO);
            response.Data = await _unitOfWork.Category.CreateCategory(category);
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

        public async Task<BaseResponse<bool>> UpdateCategory(int categoryId, CategoryRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var categoryToEdit = await CategoryById(categoryId);
            if (categoryToEdit is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }
            var category = _mapper.Map<Category>(requestDTO);
            category.CategoryId = categoryId;
            response.Data = await _unitOfWork.Category.UpdateCategory(category);
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

        public async Task<BaseResponse<bool>> DeleteCategory(int categoryId)
        {
            var response = new BaseResponse<bool>();
            var category = await CategoryById(categoryId);
            if (category is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }
            response.Data = await _unitOfWork.Category.DeleteCategory(categoryId);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR;
            }
            return response;
        }
    }
}
