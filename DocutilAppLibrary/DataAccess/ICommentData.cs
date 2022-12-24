namespace DocutilAppLibrary.DataAccess
{
    public interface ICommentData
    {
        Task CreateComment(CommentModel comment);
        Task DeleteComment(CommentModel comment);
        Task<List<CommentModel>> GetCommentByUser(BasicUserModel user);
        Task UpdateComment(CommentModel comment);
    }
}