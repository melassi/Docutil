namespace DocutilAppLibrary.DataAccess
{
    public class MongoDirectoryData : IDirectoryData
    {
        private readonly IDbConnection _db;
        private IMongoCollection<DirectoryModel> _directories;

        public MongoDirectoryData(Interfaces.IDbConnection db)
        {
            _db = db;
            _directories = db.DirectoryCollection;
        }


        //GetDirectoriesByProject<List<DirectorieModel>>
        public async Task<List<DirectoryModel>> GetDirectoriesByProject(string projectid)
        {
            var results = await _directories.FindAsync(d => d.ProjectId == projectid);
            return results.ToList();

        }

        //GetListItemsofDirectories by Project
        public async Task<List<ListItemModel>> GetListItemDirectoriesByProject(string projectId)
        {
            var results = await _directories.FindAsync(d => d.ProjectId == projectId);
            List<ListItemModel> output = new();
            foreach (var item in results.ToList())
            {
                output.Add(item.ToListItem());
            }
            return output;
        }

        //Get Directory By ID
        public async Task<DirectoryModel> GetDirectoryById(string id)
        {
            var results = await _directories.FindAsync(d => d.Id == id);
            DirectoryModel output = results.First();

            return output;
        }

        //GetDirectoriesByParent<List<DirectorieModel>>
        public async Task<List<DirectoryModel>> GetDirectoriesByParent(string parentid)
        {
            var results = await _directories.FindAsync(d => d.ParentDirectoryId == parentid);
            return results.ToList();
        }


        //GetDirectoriesByBasicUser<List<DirectorieModel>>
        public async Task<List<DirectoryModel>> GetDirectoriesByBasicUser(BasicUserModel user)
        {
            var results = await _directories.FindAsync(d => d.UserReadClaim == user);
            return results.ToList();
        }


        //UpdateDirectory
        public Task UpdateDirectory(DirectoryModel directory)
        {
            var filter = Builders<DirectoryModel>.Filter.Eq("Id", directory.Id);
            return _directories.ReplaceOneAsync(filter, directory, new ReplaceOptions { IsUpsert = true });

        }

        //CreateDirectory
        public Task CreateDirectory(DirectoryModel directory)
        {
            return _directories.InsertOneAsync(directory);

        }


    }
}
