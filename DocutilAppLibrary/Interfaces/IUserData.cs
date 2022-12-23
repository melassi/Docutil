namespace DocutilAppLibrary.Interfaces
{
    public interface IUserData
    {
        Task CreateUser(UserModel user);
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUser(string id);
        Task<UserModel> GetUserFromAuthentication(string ObjectId);
        Task UpdateUser(UserModel user);
    }
}