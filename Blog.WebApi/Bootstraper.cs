using Blog.Core.Repositories.Comments;
using Blog.Core.Repositories.Posts;
using Blog.Core.Utils;
using Blog.WebApi.Profiles;

namespace Blog.WebApi;
public static class Bootstraper
{
    public static void Init(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IFileManeger, FileManeger>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        
        services.AddAutoMapper(typeof(PostProfile));
        services.AddSwaggerGen();

    }
}
