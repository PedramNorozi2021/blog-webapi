using Blog.Core.Repositories.Posts.DTOs;
using Blog.Data.Models.Posts;

namespace Blog.Core.Repositories.Posts;

public interface IPostRepository : IBaseRepository<Post, long>
{
    /// <summary>
    /// add post and return slug
    /// </summary>
    /// <param name="command">command</param>
    /// <returns>slug</returns>
    Task<string> AddPost(AddPostDto command);
    Task<bool> ExsistSlug(string connectionString,string slug);
    Task<PostPagingDto> GetByPagination(int pageid);
    Task<PostDetailDto?> GetPostBySlug(string slug);
}


