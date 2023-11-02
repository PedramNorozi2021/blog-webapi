namespace Blog.Data.Models.Posts;
public class Post : BaseModel<long>
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    public string ImageName { get; set; }
    public string UserName { get; set; }


    #region Relationships
    public virtual ICollection<Comment> Comments { get; set; }
    #endregion
}
