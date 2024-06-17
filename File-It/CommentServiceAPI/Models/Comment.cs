namespace CommentServiceAPI.Models
{
    public class Comment
    {
        public Guid commentID { get; set; }
        public Guid UserID { get; set; }

        public string FileID { get; set; }
        public string content {  get; set; }
    }
}
