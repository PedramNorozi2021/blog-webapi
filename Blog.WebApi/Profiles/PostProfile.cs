using AutoMapper;
using Blog.Core.Repositories.Posts.DTOs;
using Blog.WebApi.ViewModels.Posts;

namespace Blog.WebApi.Profiles;
public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<AddPostViewModel, AddPostDto>().ReverseMap();
    }

}
