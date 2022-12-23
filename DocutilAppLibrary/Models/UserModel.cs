
namespace DocutilAppLibrary.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ObjectIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressField1 { get; set; }
        public string AddressField2 { get; set; }
        public string ZipCode { get; set; }
        public string Area { get; set; }
        public string Country { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserType { get; set; }
        public string SubscriptionType { get; set; }


    }
}
