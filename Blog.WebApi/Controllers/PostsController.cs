using AutoMapper;
using Blog.Core.Repositories.Posts;
using Blog.Core.Repositories.Posts.DTOs;
using Blog.Core.Utils;
using Blog.WebApi.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private IPostRepository _postRepository;
    private IMapper _mapper;
    private IConfiguration _config;

    public PostsController(IPostRepository postRepository, IMapper mapper, IConfiguration config)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _config = config;
    }


    [HttpPost]
    public async Task<IActionResult> AddPost([FromForm] AddPostViewModel model)
    {
        if (!TextUtil.IsValidSlug(model.Slug))
            return BadRequest(new { msg = "slug نا معبتر است" });

        bool isExistSlug = await _postRepository.ExsistSlug(_config.GetConnectionString("connection"), model.Slug);
        if (isExistSlug)
            return BadRequest(new { msg = "slug تکراری است" });

        var newPost = _mapper.Map<AddPostDto>(model);
        string slug = await _postRepository.AddPost(newPost);
        return new JsonResult(new { slug = slug }) { StatusCode = StatusCodes.Status201Created };

        // 1) check slug
        // 2) map viewmodel to dto
        // 3) add post
    }


    [HttpGet]
    public async Task<IActionResult> GetPosts(int pageId = 1)
    {
        var response = await _postRepository.GetByPagination(pageId);
        if (response.Posts.Count == 0)
            return NotFound();
        return Ok(response);
        
        //1) get posts by pagination from repository
    }


    [HttpGet("{slug}")]
    public async Task<IActionResult> GetPostBySlug(string slug)
    {
        var post = await _postRepository.GetPostBySlug(slug);
        if (post == null)
            return NotFound();

        return Ok(post);

        //1) find post by slug
    }
}
