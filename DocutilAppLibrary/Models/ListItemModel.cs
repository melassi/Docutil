

namespace DocutilAppLibrary.Models;

    public class ListItemModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime LastChanged { get; set; }
    public string Type { get; set; }
    

    public ListItemModel()
    {
        Id = "";
        Name = "";
        LastChanged = new();
        Type = "";
    }
}

