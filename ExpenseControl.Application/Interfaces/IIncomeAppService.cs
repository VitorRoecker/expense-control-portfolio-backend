namespace ExpenseControl.Application.Interfaces
{
    public interface IIncomeAppService
    {
        Responses.Income GetById(Guid id);
        IEnumerable<Responses.Income> GetAll(string UserId);
        Task<Responses.Identifier> Add(Requests.Income request);
        void Update(Guid incomeId, Requests.Income request);
        void Delete(Guid id);
    }
}
