using DocsStorage.Models;

namespace DocsStorage.Services
{
    public interface IDocumentService
    {
        /// <summary>
        /// Get document in format by mimeType.
        /// </summary>
        Task<IResult> GetDocument(string documentID, string mimeType);

        /// <summary>
        /// Save new document.
        /// </summary>
        Task<IResult> AddDocument(Document document);

        /// <summary>
        /// Rewrite existing document.
        /// </summary>
        Task<IResult> ModifyDocument(Document document);
    }
}
