
namespace DocutilAppLibrary.Models;

    public class BasicCommentModel
    {
    public string Id { get; set; }
    public string Comment { get; set; }
    public BasicUserModel Author { get; set; }
    public DateTime DateTimeCreated { get; set; }


    public BasicCommentModel(CommentModel comment)
    {
        Id = comment.Id;
        Comment = comment.Text;
        Author = comment.Author;
        DateTimeCreated = comment.DateTimeCreated;
    }
}

