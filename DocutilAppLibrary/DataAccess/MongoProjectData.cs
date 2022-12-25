namespace DocutilAppLibrary.DataAccess
{
    public class MongoProjectData : IProjectData
    {
        private readonly IMongoCollection<ProjectModel> _projects;
        private readonly IDbConnection _db;
        private readonly IUserData _userdata;

        public MongoProjectData(IDbConnection db)
        {
            _db = db;
            _projects = db.ProjectCollection;
        }

        public async Task<List<ProjectModel>> GetAllProjects()
        {
            var result = await _projects.FindAsync(_ => true);
            return result.ToList();

        }

        public async Task<List<ProjectModel>> GetProjectsByUser(BasicUserModel user)
        {
            var result = await _projects.FindAsync(p => p.ProjectUsers.Contains(user) || p.ProjectAdmins.Contains(user));
            return result.ToList();

        }

        public async Task UpdateProject(ProjectModel project)
        {
            await _projects.ReplaceOneAsync(p => p.Id == project.Id, project);
        }

        public async Task CreateProject(ProjectModel project)
        {
            var client = _db.Client;
            using var session = await client.StartSessionAsync();

            session.StartTransaction();
            try
            {
                var db = client.GetDatabase(_db.DbName);
                var projectsInTransaction = db.GetCollection<ProjectModel>(_db.ProjectCollectionName);
                await projectsInTransaction.InsertOneAsync(project);

                await session.CommitTransactionAsync();

            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;

            }


        }


    }
}
