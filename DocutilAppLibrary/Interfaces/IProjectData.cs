namespace DocutilAppLibrary.Interfaces
{
    public interface IProjectData
    {
        Task CreateProject(ProjectModel project);
        Task<List<ProjectModel>> GetAllProjects();
        Task<List<ProjectModel>> GetProjectsByUser(BasicUserModel user);
        Task<ProjectModel> GetProjectsById(string id);
        Task UpdateProject(ProjectModel project);
    }
}