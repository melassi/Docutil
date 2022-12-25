

namespace DocutilAppLibrary.Models
{
    public class CommentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public BasicUserModel Author { get; set; }
        public string Text { get; set; }    
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeEdited { get; set; }
        public string CommentedRevision { get; set; }
        public string DocumentId { get; set; }

    }
}
