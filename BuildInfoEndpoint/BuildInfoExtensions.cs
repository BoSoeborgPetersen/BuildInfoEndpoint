using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BuildInfoEndpoint
{
    public static class BuildInfoExtensions
    {
        private static BuildInfo? Data;

        public static RequestDelegate BuildInfoEndpoint(string fileName = ".buildinfo.json")
        {
            Data = BuildInfo.ReadFromFile(fileName);

            return async context =>
            {
                context.Response.ContentType = "text/HTML";
                await context.Response.WriteAsync(Data.EndpointText);
            };
        }

        public static IEndpointConventionBuilder MapBuildInfoEndpoint(this IEndpointRouteBuilder endpoints, string url, string fileName = ".buildinfo.json")
        {
            return endpoints.MapGet(url, BuildInfoEndpoint(fileName));
        }
    }
}
