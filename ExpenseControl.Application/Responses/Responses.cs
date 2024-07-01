namespace ExpenseControl.Application
{
    public static class Responses
    {
        public record UserToken(Guid UserId, string Token, DateTime Expiration)
        {
            public static implicit operator UserToken(Domain.Entities.UserToken userToken)
                => new(userToken.UserId, userToken.Token, userToken.Expiration);
        }

        public record Category(Guid Id, string UserId, DateTime InclusionDate, string Name, string Description, int Type)
        {
            public static implicit operator Category(Domain.Entities.Category category)
                => new(category.Id, category.UserId, category.InclusionDate, category.Name, category.Description, (int)category.Type);
        }

        public record Expense(Guid Id, string UserId, Guid CategoryId, DateTime InclusionDate, string Description, decimal Amount, int Type, DateTime? ExpirationDate)
        {
            public static implicit operator Expense(Domain.Entities.Expense expense)
                => new(expense.Id, expense.UserId, expense.CategoryId, expense.InclusionDate, expense.Description, expense.Amount, (int)expense.Type, expense.ExpirationDate);
        }

        public record Income(Guid Id, string UserId, Guid CategoryId, DateTime InclusionDate, string Description, decimal Amount, int Type, DateTime EntryDate)
        {
            public static implicit operator Income(Domain.Entities.Income income)
                => new(income.Id, income.UserId, income.CategoryId, income.InclusionDate, income.Description, income.Amount, (int)income.Type, income.EntryDate);
        }

        public record Identifier(Guid Id);
    }
}
