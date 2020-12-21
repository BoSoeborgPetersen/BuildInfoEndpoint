using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;

namespace BuildInfoEndpoint
{
    public static class BuildInfoExtensions
    {
        public static IEndpointConventionBuilder MapBuildInfoEndpoint(this IEndpointRouteBuilder endpoints, IHostEnvironment env, string url = "/build/info", string fileName = ".buildinfo.json")
        {
            return endpoints.MapGet(url, async context =>
            {
                var _info = new BuildInfo(env, fileName);
                context.Response.ContentType = "text/HTML";
                var repoLink = $"<a href=\"{_info.RepoUrl}\">{_info.ShortGitHash}</a>";
                var pipelineLink = $"<a href=\"{_info.PipelineUrl}\">{_info.Version}</a>";
                await context.Response.WriteAsync($"Powered by {RuntimeInformation.FrameworkDescription} and deployed from commit {repoLink} via build {pipelineLink}");
            });
        }
    }
}
