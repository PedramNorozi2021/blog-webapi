
using Blog.Data.Models.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configuration.Posts;

internal class CommentConfuration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {

        builder.ToTable("Comments", "post");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasDefaultValueSql("NEWID()");

        builder
            .HasOne(t => t.Post)
            .WithMany(t => t.Comments)
            .HasForeignKey(t => t.PostId);
    }
}

