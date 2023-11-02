using Blog.Data.Configuration.Posts;
using Blog.Data.Models.Posts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostConfuration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentConfuration).Assembly);


        base.OnModelCreating(modelBuilder);
    }
}
