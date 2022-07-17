namespace Sample.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate => Id == 0 ? DateTime.Now : CreatedDate;
}
