namespace Domain.AggregateRoots
{
    public class BaseAggregateRoot
    {
        private DateTime _createdTime;
        private DateTime _updatedTime;


        public int Id { get; set; }
        public DateTime CreatedTime
        {
            get { return _createdTime; }
            private set { _createdTime = DateTime.Now; }
        }
        public Nullable<DateTime> UpdatedTime
        {
            get { return _updatedTime; }
            private set { _updatedTime = Id == 0 ? DateTime.MinValue : DateTime.Now; }
        }
    }
}
