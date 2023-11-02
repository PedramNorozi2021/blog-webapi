
using Blog.Core.Repositories.Posts.DTOs;
using Blog.Core.Utils;
using Blog.Data.Context;
using Blog.Data.Models.Posts;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Repositories.Posts;

public class PostRepository : BaseRepository<Post, long>, IPostRepository
{
    private IFileManeger _fileManeger;
    public PostRepository(ApplicationDbContext dbContext, IFileManeger fileManeger)
        : base(dbContext)
    {
        _fileManeger = fileManeger;
    }


    public async Task<string> AddPost(AddPostDto command)
    {
        string fileName = _fileManeger.UploadFile(PathUtil.postImageDir, command.File);
        await _db.Posts.AddAsync(new Post
        {
            Body = command.Body,
            ImageName = fileName,
            Slug = command.Slug,
            Title = command.Title,
            UserName = command.UserName
        });
        await _db.SaveChangesAsync();
        return command.Slug;
    }

    public async Task<bool> ExsistSlug(string connectionString, string slug)
    {
        using var sqlConnection = new SqlConnection(connectionString);
        int res =
           await sqlConnection.QueryFirstAsync<int>("Select COUNT(*) From post.Posts Where slug=@slug", new { slug });

        if (res == 0)
            return false;

        return true;
    }

    public async Task<PostPagingDto> GetByPagination(int pageid)
    {
        int take = 5;
        int skip = (pageid - 1) * take;

        var posts = _db.Posts.AsQueryable();


        PagingDto pagingDto = new PagingDto(take, pageid, posts.Count());

        return new PostPagingDto()
        {
            Paging = pagingDto,
            Posts = await posts.Skip(skip)
            .Take(take)
            .Select(t => new PostDto
            {
                Id = t.Id,
                Body = t.Body,
                Slug = t.Slug,
                CreationDate = t.CreationDate.ToLongDateString(),
                ImageUrl = Path.Combine(PathUtil.postImageDir, t.ImageName).Replace("wwwroot","").Replace("\\","/"),
                Title = t.Title,
                UserName = t.UserName
            }).ToListAsync()
        };
    }

    public async Task<PostDetailDto?> GetPostBySlug(string slug)
    {
        var post = await _db.Posts.Include(t => t.Comments)
            .SingleOrDefaultAsync(t => t.Slug.Equals(slug));

        if (post == null)
            return null;

        return new PostDetailDto()
        {
            Id = post.Id,
            CreationDate = post.CreationDate.ToLongDateString(),
            Title = post.Title,
            ImageUrl = Path.Combine(PathUtil.postImageDir, post.ImageName).Replace("wwwroot", "").Replace("\\", "/"),
            UserName = post.UserName,
            Body = post.Body,
            Slug = post.Slug,
            Comments = post.Comments.Select(c => new PostCommentDto
            {
                CreateDate = c.CreationDate.ToLongDateString(),
                Text = c.Text,
                UserName = c.UserName
            }).ToList()
        };
    }
}


