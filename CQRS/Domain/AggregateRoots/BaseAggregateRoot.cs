namespace Domain.AggregateRoots
{
    public class BaseAggregateRoot
    {
        public int Id { get; set; }
        public DateTime CreatedTime => DateTime.Now;
        public Nullable<DateTime> UpdatedTime => Id == 0 ? null : DateTime.Now;
    }
}
