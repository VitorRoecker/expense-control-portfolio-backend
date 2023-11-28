using ExpenseControl.Application.ViewModels.Base;
using ExpenseControl.Domain.ValueObjects;

namespace ExpenseControl.Application.ViewModels
{
    public class UserTokenViewModel : BaseViewModel<UserTokenViewModel, UserToken>
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }

        public override UserToken ConvertToDomain()
            => new() { Token = Token, Expiration = Expiration };

        public override UserTokenViewModel ConvertToViewModel(UserToken userToken)
            => new() { Token = userToken.Token, Expiration = userToken.Expiration };

        public override UserToken CreateDomain()
            => new() { Token = Token, Expiration = Expiration };
    }
}
