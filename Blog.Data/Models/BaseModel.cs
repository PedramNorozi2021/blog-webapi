namespace Blog.Data.Models;
public class BaseModel<T>
{
    public T Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
