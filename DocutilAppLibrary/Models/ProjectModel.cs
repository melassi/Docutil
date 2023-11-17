

namespace DocutilAppLibrary.Models
{
    public class ProjectModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<BasicUserModel> ProjectUsers { get; set; }
        public List<BasicUserModel> ProjectAdmins { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectLocation { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public List<IListItem> FavouriteItems { get; set; }
        public DirectoryModel RootDirectory { get; set; }



    }
}
