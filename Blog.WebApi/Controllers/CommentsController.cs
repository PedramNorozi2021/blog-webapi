using AutoMapper;
using Blog.Core.Repositories.Comments;
using Blog.Data.Models.Posts;
using Blog.WebApi.ViewModels.Comments;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class CommentsController : ControllerBase
    {
        private ICommentRepository _commentRepository;
        private IMapper _mapper;

        public CommentsController(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentViewModel viewModel)
        {
            Comment comment = _mapper.Map<Comment>(viewModel); ; 
            await _commentRepository.AddAsync(comment);
            
            return new JsonResult(new { msg = "عملیات موفق امیز بود" })
            { StatusCode = StatusCodes.Status201Created };
        
            // 1) map viewModel to model
            // 2) add comment to database
        }
    }
}
