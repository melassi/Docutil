namespace DocutilAppLibrary.Interfaces
{
    public interface IDirectoryData
    {
        Task CreateDirectory(DirectoryModel directory);
        Task<List<DirectoryModel>> GerDirectoriesByProject(string projectid);
        Task<List<DirectoryModel>> GetDirectoriesByBasicUser(BasicUserModel user);
        Task<List<DirectoryModel>> GetDirectoriesByParent(string parentid);
        Task UpdateDirectory(DirectoryModel directory);
    }
}