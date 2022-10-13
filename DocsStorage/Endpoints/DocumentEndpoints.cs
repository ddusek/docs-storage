using DocsStorage.Models;
using DocsStorage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocsStorage.Endpoints
{
    public class DocumentEndpoints
    {
        public static void Map(IEndpointRouteBuilder endpoint)
        {
            // Get document by its ID.
            endpoint.MapGet("/api/document/{documentID}", async (
                HttpContext httpContext,
                [FromServices]IDocumentService documentService,
                string documentID) =>
            {
                return await documentService.GetDocument(documentID, httpContext.Request.ContentType);
            });

            // Add new document.
            endpoint.MapPost("/api/document", async ([FromServices] IDocumentService documentService, [FromBody]Document document) =>
            {
                if (!document.IsValid())
                {
                    return Results.BadRequest();
                }
                return await documentService.AddDocument(document);
            });

            // Modify document by its ID.
            endpoint.MapPut("/api/document", async ([FromServices] IDocumentService documentService, Document document) =>
            {
                if (!document.IsValid())
                {
                    return Results.BadRequest();
                }
                return await documentService.ModifyDocument(document);
            });
        }
    }
}
