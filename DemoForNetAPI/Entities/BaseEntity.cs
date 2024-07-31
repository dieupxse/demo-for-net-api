namespace DemoForNetAPI.Entities;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public DateTime Created { get; set; }
}