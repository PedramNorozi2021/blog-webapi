
using Blog.Data.Models.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configuration.Posts;
internal class PostConfuration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts", "post");
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Slug).IsUnique(true);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(t => t.ImageName)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(t => t.Body)
            .IsRequired();
    }
}

