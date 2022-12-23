

namespace DocutilAppLibrary.Models
{
    public class ToDoListModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectId { get; set; }
        public string ToDoListName { get; set; }
        public string ToDoListDescription { get; set; }
        public List<ToDoListItemModel> ToDoListItems { get; set; }

    }
}
