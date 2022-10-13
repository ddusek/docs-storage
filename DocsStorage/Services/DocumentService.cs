using DocsStorage.Converters.Documents;
using DocsStorage.Models;
using DocsStorage.Services.Storage;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace DocsStorage.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IFileService _fileService;

        public DocumentService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<IResult> GetDocument(string documentID, string mimeType)
        {
            var jsonContent = await _fileService.ReadFileContent(documentID);
            if (string.IsNullOrEmpty(jsonContent))
            {
                return Results.NotFound();
            }

            if (mimeType == Constants.MimeTypes.Json)
            {
                return Results.Text(jsonContent, mimeType);
            }

            var converter = ConverterFactory.GetFormatConverter(mimeType);
            if (converter == null)
            {
                return Results.BadRequest($"{mimeType} format not implemented");
            }
            var formattedDocument = converter.Convert(jsonContent);

            return Results.Text(formattedDocument, mimeType);
        }

        public async Task<IResult> AddDocument(Document document)
        {
            var content = JsonSerializer.Serialize(document);
            var result = await _fileService.WriteToFile(content, document.ID);
            return result ? Results.Ok() : Results.Conflict();
        }

        public async Task<IResult> ModifyDocument(Document document)
        {
            var content = JsonSerializer.Serialize(document);
            if (string.IsNullOrEmpty(content))
            {
                return Results.BadRequest();
            }
            var result = await _fileService.ChangeFile(content, document.ID);
            if (!result)
            {
                return Results.BadRequest();
            }
            return Results.Ok();
        }
    }
}
