namespace ExpenseControl.Domain.Entities
{
    public record UserToken
    {
        public Guid UserId { get; set; }
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
