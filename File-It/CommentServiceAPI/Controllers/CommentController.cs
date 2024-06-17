using CommentServiceAPI.Interface;
using CommentServiceAPI.Messaging;
using CommentServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommentServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly SendMessage _sendMessage;
        private readonly ICommentRepository _commentRepository;
        public CommentController(IConfiguration configuration, ICommentRepository repo) 
        {
            _sendMessage = new SendMessage();
            _sendMessage.createChannel(configuration);
            _commentRepository = repo;
        }

        [HttpGet("Get/All")]
        public async Task<List<Comment>> GetAllComments()
        {
            return _commentRepository.GetAllComments();

        }

        [HttpPost("Create")]
        public async Task CreateComment(Comment commentmodel, string fileid)
        {
            //ADD comment shit
            _commentRepository.CreateComment(commentmodel);

            //messaging
            _sendMessage.CommentCreated(fileid);
            
        }

        
    }
}
