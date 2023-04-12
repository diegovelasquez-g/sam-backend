namespace SAM.Application.DTOS.Response
{
    public class UserResponseDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
