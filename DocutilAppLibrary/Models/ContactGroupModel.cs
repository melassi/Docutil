

namespace DocutilAppLibrary.Models
{
    public class ContactGroupModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectId { get; set; }
        public string ContactGroupName { get; set; }
        public List<ContactModel> Contacts { get; set; }


    }
}
