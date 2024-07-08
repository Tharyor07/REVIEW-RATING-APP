namespace repository_pattern.DTO
{
    public record ResetPasswordDTO
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
