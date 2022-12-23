

namespace DocutilAppLibrary.Models
{
    public class ContactModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressField1 { get; set; }
        public string AddressField2 { get; set; }
        public string ZipCode { get; set; }
        public string Area { get; set; }
        public string Country { get; set; }
        public string ContactGroupId { get; set; }
        public string PhoneNr { get; set; }
        public string BusinessName { get; set; }

    }
}
