namespace DocutilAppLibrary.Interfaces
{
    public interface IDocumentData
    {
        Task CreateDocument(DocumentModel document);
        Task CreateRevision(DocumentModel document, RevisionModel revision);
        Task DeleteDocument(DocumentModel document);
        Task DeleteRevision(DocumentModel document, RevisionModel revision);
        Task<List<DocumentModel>> GetAllDocumentsByDirectory(string parentId);
        Task<List<DocumentModel>> GetAllDocumentsByProject(string projectId);
        Task<List<ListItemModel>> GetListItemAllDocumentsByProject(string projectId);
        Task<List<DocumentModel>> GetAllDocumentsByUser(BasicUserModel user);
        Task<DocumentModel> GetDocumentById(string documentId);
    }
}