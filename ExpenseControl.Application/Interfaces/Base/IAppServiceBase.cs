namespace ExpenseControl.Application.Interfaces.Base
{
    public interface IAppServiceBase<TViewModel> where TViewModel : class
    {
        public Task<TViewModel> GetById(Guid id);
        public Task<List<TViewModel>> GetAll();
        public void Add(TViewModel income);
        public void Update(TViewModel income);
        public void Delete(Guid id);
    }
}
