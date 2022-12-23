

namespace DocutilAppLibrary.Models
{
    public class RevisionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RevisionId { get; set; }
        public string AzureFileId { get; set; }
        public BasicUserModel RevisionAuthor { get; set; }
        public DateTime DateTimeCreated { get; set; }

    }
}
