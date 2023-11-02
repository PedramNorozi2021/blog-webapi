using AutoMapper;
using Blog.Data.Models.Posts;
using Blog.WebApi.ViewModels.Comments;

namespace Blog.WebApi.Profiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<AddCommentViewModel, Comment>().ReverseMap();
    }
}