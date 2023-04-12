namespace SAM.Application.DTOS.Response
{
    public class CategoryResponseDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
