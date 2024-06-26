﻿using ExpenseControl.Application.ViewModels;
using ExpenseControl.Domain.Services.Requests;

namespace ExpenseControl.Application.Interfaces
{
    public interface IUserAppService
    {
        public Task<UserTokenViewModel> CreateUser(CreateUserRequest createUserRequest);
    }
}
