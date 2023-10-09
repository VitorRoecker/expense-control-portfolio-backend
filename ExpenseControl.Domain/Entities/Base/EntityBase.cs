namespace ExpenseControl.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime InclusionDate { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            InclusionDate = DateTime.Now;
        }

        public abstract bool InsertValidation();
        public abstract bool UpdateValidation();
    }
}
