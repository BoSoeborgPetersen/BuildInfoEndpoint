using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BuildInfoEndpoint
{
    public static class BuildInfoExtensions
    {
        public static BuildInfo _info;

        public static RequestDelegate BuildInfoEndpoint(string fileName = ".buildinfo.json")
        {
            _info = new BuildInfo(fileName);

            return async context =>
            {
                context.Response.ContentType = "text/HTML";
                await context.Response.WriteAsync(_info.EndpointText);
            };
        }

        public static IEndpointConventionBuilder MapBuildInfoEndpoint(this IEndpointRouteBuilder endpoints, string url, string fileName = ".buildinfo.json")
        {
            return endpoints.MapGet(url, BuildInfoEndpoint(fileName));
        }
    }
}
