
using Blog.Data.Context;
using Blog.Data.Models.Posts;

namespace Blog.Core.Repositories.Comments;

public class CommentRepository :BaseRepository<Comment,string>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext db)
        :base(db)
    {}
}
