namespace ExpenseControl.Domain.Services
{
    public static class Requests
    {
        public record Login(string DocumentoFederal, string Password);
        public record CreateUser(string DocumentoFederal, string Email, string Password);
        public record DeleteUser(string UserId)
        {
            public static implicit operator DeleteUser(Guid userId)
                => new(userId.ToString());
        }
    }
}
