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
        private static readonly string _buildFileName = ".buildinfo.json";
        public string GitHash { get; } = "000000";
        public string ShortGitHash => GitHash.Count() >= 6 ? GitHash.Substring(0, 6) : "000000";
        public string Version { get; } = "000000";
        public string DevopsRepoUrl { get; } = "000000";
        public string DevopsPipelineUrl { get; } = "00000000.0";

        public BuildInfo(IHostEnvironment hostEnvironment)
        {
            var buildFilePath = Path.Combine(hostEnvironment.ContentRootPath, _buildFileName);

            if (File.Exists(buildFilePath))
            {
                dynamic jToken = JToken.Parse(File.ReadAllText(buildFilePath));

                GitHash = jToken.GitHash ?? GitHash;
                Version = jToken.Version ?? Version;
                DevopsRepoUrl = jToken.DevopsRepoUrl ?? DevopsRepoUrl;
                DevopsPipelineUrl = jToken.DevopsPipelineUrl ?? DevopsPipelineUrl;
            }

            Console.WriteLine($"Powered by {RuntimeInformation.FrameworkDescription} and deployed from commit {ShortGitHash} with version {Version}");
        }
    }
}