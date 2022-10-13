using DocsStorage.Services;
using DocsStorage.Services.Storage;

namespace DocsStorage
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDocumentService, DocumentService>();
            services.AddSingleton<IFileService, FileService>();
            return services;
        }
    }
}
