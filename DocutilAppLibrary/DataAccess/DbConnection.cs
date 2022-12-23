using Microsoft.Extensions.Configuration;

namespace DocutilAppLibrary.DataAccess;
public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;
    private string _connectionId = "mondodb";

    public string DbName { get; set; }
    public MongoClient Client { get; private set; }


    #region CollectionNameStrings
    public string UserCollectionName { get; private set; } = "users";
    public string ToDoListCollectionName { get; private set; } = "todolists";
    public string SubscriptionCollectionName { get; private set; } = "subscriptions";
    public string ProjectCollectionName { get; private set; } = "projects";
    public string CommentCollectionName { get; private set; } = "comments";
    public string DocumentCollectionName { get; private set; } = "documents";
    public string ContacGroupCollectionName { get; private set; } = "contactgroups";
    public string DirectoryCollectionName { get; private set; } = "directories";
    #endregion

    #region MongoCollectionDefinitions
    public IMongoCollection<UserModel> UserCollection { get; private set; }
    public IMongoCollection<ToDoListModel> ToDoListCollection { get; private set; }
    public IMongoCollection<SubscriptionModel> SubscriptionCollection { get; private set; }
    public IMongoCollection<ProjectModel> ProjectCollection { get; private set; }
    public IMongoCollection<CommentModel> CommentCollection { get; private set; }
    public IMongoCollection<DocumentModel> DocumentCollection { get; private set; }
    public IMongoCollection<ContactGroupModel> ContactGroupCollection { get; private set; }
    public IMongoCollection<DirectoryModel> DirectoryCollection { get; private set; }


    #endregion

    public DbConnection(IConfiguration config)
    {
        _config = config;
        Client = new MongoClient(_config.GetConnectionString(_connectionId));
        DbName = _config["DatabaseName"];
        _db = Client.GetDatabase(DbName);

        UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
        ToDoListCollection = _db.GetCollection<ToDoListModel>(ToDoListCollectionName);
        SubscriptionCollection = _db.GetCollection<SubscriptionModel>(SubscriptionCollectionName);
        ProjectCollection = _db.GetCollection<ProjectModel>(ProjectCollectionName);
        CommentCollection = _db.GetCollection<CommentModel>(CommentCollectionName);
        DocumentCollection = _db.GetCollection<DocumentModel>(DocumentCollectionName);
        ContactGroupCollection = _db.GetCollection<ContactGroupModel>(ContacGroupCollectionName);
        DirectoryCollection = _db.GetCollection<DirectoryModel>(DirectoryCollectionName);

    }
}



