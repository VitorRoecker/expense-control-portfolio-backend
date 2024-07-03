namespace ExpenseControl.Domain.Services
{
    public static class Requests
    {
        public record Login(string DocumentoFederal, string Password);
        public record CreateUser(string DocumentoFederal, string Email, string PhoneNumber, string Password);
    }
}
