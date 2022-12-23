namespace DocutilAppLibrary.Interfaces
{
    public interface IDbConnection
    {
        MongoClient Client { get; }
        IMongoCollection<CommentModel> CommentCollection { get; }
        string CommentCollectionName { get; }
        string ContacGroupCollectionName { get; }
        IMongoCollection<ContactGroupModel> ContactGroupCollection { get; }
        string DbName { get; set; }
        IMongoCollection<DirectoryModel> DirectoryCollection { get; }
        string DirectoryCollectionName { get; }
        IMongoCollection<DocumentModel> DocumentCollection { get; }
        string DocumentCollectionName { get; }
        IMongoCollection<ProjectModel> ProjectCollection { get; }
        string ProjectCollectionName { get; }
        IMongoCollection<SubscriptionModel> SubscriptionCollection { get; }
        string SubscriptionCollectionName { get; }
        IMongoCollection<ToDoListModel> ToDoListCollection { get; }
        string ToDoListCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionName { get; }
    }
}