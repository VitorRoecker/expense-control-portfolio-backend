﻿namespace ExpenseControl.Domain.Services.Requests
{
    public class CreateUserRequest
    {
        public string DocumentoFederal { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
