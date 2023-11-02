namespace Blog.Data.Models.Posts;

public class Comment : BaseModel<string>
{
    public long PostId { get; set; }
    public string Text { get; set; }
    public string UserName { get; set; }


    #region Relationships
    public virtual Post Post { get; set; }
    #endregion
}