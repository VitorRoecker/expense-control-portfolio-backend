namespace ExpenseControl.Application.Interfaces
{
    public interface IExpenseAppService
    {
        Responses.Expense GetById(Guid id);
        IEnumerable<Responses.Expense> GetAll(string UserId);
        Task<Responses.Identifier> Add(Requests.Expense request);
        void Update(Guid expenseId, Requests.Expense request);
        void Delete(Guid id);
    }
}
