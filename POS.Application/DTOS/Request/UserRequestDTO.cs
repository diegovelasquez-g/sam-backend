namespace SAM.Application.DTOS.Request
{
    public  class UserRequestDTO
    {
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
