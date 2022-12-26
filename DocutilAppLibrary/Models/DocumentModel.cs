
namespace DocutilAppLibrary.Models
{
    public class DocumentModel : IListItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string DocumentDescription { get; set; }
        public List<BasicCommentModel> Comments { get; set; }
        public List<BasicUserModel> UsersReadClaim { get; set; }
        public List<RevisionModel> Revisions { get; set; }
        public string DocumentType { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string DocumentSize { get; set; }
        public string ProjectId { get; set; }
        public string ParentDirectoryId { get; set; }


        public ListItemModel ToListItem()
        {
            ListItemModel item = new();
            item.Id = Id;
            item.Name = Name;
            if(Revisions.Count > 0)
            {
                item.LastChanged = Revisions.Last().DateTimeCreated;
            }
            else
            {
                item.LastChanged = DateTimeCreated; 
            }

            item.Type = DocumentType;
            return item;

        }
    }
}
