using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;

namespace BuildInfoEndpoint
{
    public static class BuildInfoExtensions
    {
        public static IEndpointConventionBuilder MapBuildInfoEndpoint(this IEndpointRouteBuilder endpoints, string path, IHostEnvironment env)
        {
            return endpoints.MapGet(path, async context =>
            {
                var _info = new BuildInfo(env);
                context.Response.ContentType = "text/HTML";
                var repoLink = $"<a href=\"{_info.DevopsRepoUrl}\">{_info.ShortGitHash}</a>";
                var pipelineLink = $"<a href=\"{_info.DevopsPipelineUrl}\">{_info.Version}</a>";
                await context.Response.WriteAsync($"Powered by {RuntimeInformation.FrameworkDescription} and deployed from commit {repoLink} via build {pipelineLink}");
            });
        }
    }
}
