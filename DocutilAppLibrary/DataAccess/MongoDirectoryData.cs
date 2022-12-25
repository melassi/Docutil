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
        public async Task<List<DirectoryModel>> GerDirectoriesByProject(string projectid)
        {
            var results = await _directories.FindAsync(d => d.Id == projectid);
            return results.ToList();

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
