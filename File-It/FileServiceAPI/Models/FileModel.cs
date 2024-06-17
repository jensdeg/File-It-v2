using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FileServiceAPI.Models
{
    public class FileModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get;  set; }

        public string FileName { get; set; } = null!;
        public string Content { get; set; } = null!;


        //comes from commentService through rabbitMQ
        public int CommentCount { get; private set; } = 0;


        public void AddCommentCount()
        {
            CommentCount++;
        }
    }
}
