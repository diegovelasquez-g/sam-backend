using Microsoft.AspNetCore.Mvc;
using SAM.Application.DTOS.Request;
using SAM.Application.Interfaces;

namespace SAM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;
        public CategoryController(ICategoryApplication categoryApplication)
        {
            this._categoryApplication = categoryApplication;
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCategories()
        {
            var response = await _categoryApplication.ListSelectCategories();
            return Ok(response);
        }

        [HttpGet("All")]
        public async Task<IActionResult> ListSelectAllCategories()
        {
            var response = await _categoryApplication.ListSelectAllCategories();
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequestDTO requestDTO)
        {
            var response = await _categoryApplication.CreateCategory(requestDTO);
            return Ok(response);
        }

        [HttpPut("Edit/{categoryId:int}")]
        public async Task<IActionResult> EditCategory(int categoryId, [FromBody] CategoryRequestDTO requestDTO)
        {
            var response = await _categoryApplication.UpdateCategory(categoryId, requestDTO);
            return Ok(response);
        }

        [HttpPut("Delete/{categoryId:int}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var response = await _categoryApplication.DeleteCategory(categoryId);
            return Ok(response);
        }


    }
}
