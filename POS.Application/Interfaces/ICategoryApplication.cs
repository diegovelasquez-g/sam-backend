using SAM.Application.Commons.Bases;
using SAM.Application.DTOS.Request;
using SAM.Application.DTOS.Response;

namespace SAM.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<IEnumerable<CategorySelectResponseDTO>>> ListSelectCategories();
        Task<BaseResponse<IEnumerable<CategorySelectResponseDTO>>> ListSelectAllCategories();
        Task<BaseResponse<CategoryResponseDTO>> CategoryById(int categoryId);
        Task<BaseResponse<bool>> CreateCategory(CategoryRequestDTO requestDTO);
        Task<BaseResponse<bool>> UpdateCategory(int categoryId, CategoryRequestDTO requestDTO);
        Task<BaseResponse<bool>> DeleteCategory(int categoryId);
    }
}
