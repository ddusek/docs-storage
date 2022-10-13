using DocsStorage.Endpoints;

namespace DocsStorage
{
    public static class EndpointsExtensions
    {
        public static void MapEndpoints(this IEndpointRouteBuilder endpointBuilder)
        {
            DocumentEndpoints.Map(endpointBuilder);
        }
    }
}
