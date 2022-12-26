namespace DocutilAppLibrary.Interfaces
{
    public interface IDirectoryData
    {
        Task CreateDirectory(DirectoryModel directory);
        Task<List<DirectoryModel>> GetDirectoriesByProject(string projectid);

        Task<List<ListItemModel>> GetListItemDirectoriesByProject(string projectId);
        Task<DirectoryModel> GetDirectoryById(string id);
        Task<List<DirectoryModel>> GetDirectoriesByBasicUser(BasicUserModel user);
        Task<List<DirectoryModel>> GetDirectoriesByParent(string parentid);
        Task UpdateDirectory(DirectoryModel directory);
    }
}