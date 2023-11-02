
namespace Blog.Core.Repositories.Posts.DTOs;
public class PagingDto
{
    public PagingDto(int take, int pageId, float countEntity)
    {
        CurrentPage = pageId;
        EndPage = (int)Math.Ceiling(Convert.ToDecimal(countEntity / take));
    }
    public float CurrentPage { get; set; }
    public int EndPage { get; set; }
}

public class PostDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string UserName { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }
    public string CreationDate { get; set; }
}
public class PostPagingDto
{
    public List<PostDto> Posts { get; set; }
    public PagingDto Paging { get; set; }
}

