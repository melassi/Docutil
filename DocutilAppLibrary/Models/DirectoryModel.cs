

namespace DocutilAppLibrary.Models
{
    public class DirectoryModel : IListItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string DirectoryDescription { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeEdited { get; set; }
        public string ParentDirectoryId { get; set; }
        public string ProjectId { get; set; }
        public string DirectorySharePassword { get; set; }
        public string DirectoryShareState { get; set; }
        public string DirectoryTipps { get; set; }
        public string DirectoryBreadcrumbs { get; set; }
        public string DirectoryIcon { get; set; }
        public BasicUserModel UserReadClaim { get; set; }

        public ListItemModel ToListItem()
        {
            ListItemModel item = new();
            item.Id = Id;
            item.Name = Name;
            item.LastChanged = DateTimeEdited;
            item.Type = "Directory";
            return item;
        }
    }
}
