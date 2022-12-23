using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DocutilAppLibrary.DataAccess;
public class DbConnection
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
    public IMongoCollection<ToDoListModel> MyProperty { get; private set; }
    public IMongoCollection< MyProperty { get; private set; }

    #endregion
}

