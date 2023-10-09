namespace ExpenseControl.Application.ViewModels.Base
{
    public abstract class BaseViewModel<T, TDomain>
    {
        public abstract T ConvertToViewModel(TDomain domain);
        public abstract TDomain ConvertToDomain();
    }
}
