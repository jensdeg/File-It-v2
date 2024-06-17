using CommentServiceAPI.Models;

namespace CommentServiceAPI.Interface
{
    public interface ICommentRepository
    {
        void CreateComment(Comment comment);
        void DeleteAllCommentsFromFile(string fileID);

        List<Comment> GetAllComments();
    }
}
