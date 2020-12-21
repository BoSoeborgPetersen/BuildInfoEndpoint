using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace BuildInfoEndpoint
{
    public class BuildInfo
    {
        public string GitHash { get; } = "000000";
        public string ShortGitHash => GitHash.Count() >= 6 ? GitHash.Substring(0, 6) : "000000";
        public string Version { get; } = "000000";
        public string RepoUrl { get; } = "000000";
        public string PipelineUrl { get; } = "00000000.0";

        public BuildInfo(IHostEnvironment hostEnvironment, string buildInfoFileName)
        {
            var buildFilePath = Path.Combine(hostEnvironment.ContentRootPath, buildInfoFileName);

            if (File.Exists(buildFilePath))
            {
                dynamic jToken = JToken.Parse(File.ReadAllText(buildFilePath));

                GitHash = jToken.GitHash ?? GitHash;
                Version = jToken.Version ?? Version;
                RepoUrl = jToken.DevopsRepoUrl ?? RepoUrl;
                PipelineUrl = jToken.DevopsPipelineUrl ?? PipelineUrl;
            }

            Console.WriteLine($"Powered by {RuntimeInformation.FrameworkDescription} and deployed from commit {ShortGitHash} with version {Version}");
        }
    }
}