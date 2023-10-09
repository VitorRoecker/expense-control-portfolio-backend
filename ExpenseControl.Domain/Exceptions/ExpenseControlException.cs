namespace ExpenseControl.Domain.Exceptions
{
    public class ExpenseControlException : Exception
    {
        public ExpenseControlException(string message) : base(message) { }

        public ExpenseControlException(string message, Exception inner) : base(message, inner) { }
    }
}
