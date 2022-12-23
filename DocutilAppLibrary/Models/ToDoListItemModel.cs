

namespace DocutilAppLibrary.Models
{
    public class ToDoListItemModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ElementTitle { get; set; }
        public bool IsElementCompleted { get; set; }

    }
}
