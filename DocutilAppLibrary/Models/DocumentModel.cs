
namespace DocutilAppLibrary.Models
{
    public class DocumentModel : IListItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public List<BasicCommentModel> Comments { get; set; }
        public List<BasicUserModel> UsersReadClaim { get; set; }
        public List<RevisionModel> Revisions { get; set; }
        public string DocumentType { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string DocumentSize { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectId { get; set; }
        public string ParentDirectoryId { get; set; }



    }
}
