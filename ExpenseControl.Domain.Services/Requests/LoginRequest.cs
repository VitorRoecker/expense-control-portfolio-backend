namespace ExpenseControl.Domain.Services.Requests
{
    public class LoginRequest
    {
        public string? DocumentoFederal { get; set; }
        public string? Password { get; set; }
    }
}
