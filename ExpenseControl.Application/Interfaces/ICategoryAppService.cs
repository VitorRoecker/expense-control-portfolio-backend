namespace ExpenseControl.Application.Interfaces
{
    public interface ICategoryAppService
    {
        Responses.Category GetById(Guid id);
        IEnumerable<Responses.Category> GetAll(string UserId);
        Task<Responses.Identifier> Add(Requests.Category request);
        void Update(Guid categoryId, Requests.Category request);
        void Delete(Guid id);
    }
}
