using CommentServiceAPI.Interface;
using CommentServiceAPI.Models;
using System.Runtime.CompilerServices;

namespace CommentServiceAPI.Repos
{
    public class MockCommentRepo : ICommentRepository
    {

        private List<Comment> comments;
        public MockCommentRepo() 
        { 
            comments = new List<Comment>();
        }

        public void CreateComment(Comment comment)
        {
            comments.Add(comment);
        }
        public void DeleteAllCommentsFromFile(string fileID)
        {
            foreach (Comment comment in comments.ToList())
            {
                if (comment.FileID == fileID)
                {
                    comments.Remove(comment);
                }
            }
        }

        public List<Comment> GetAllComments()
        {
            return comments;
        }
    }
}
