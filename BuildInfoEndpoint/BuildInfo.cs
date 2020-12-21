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
        public string Version { get; } = "000000";
        public string GitHash { get; } = "000000";
        public string RepoUrl { get; } = "000000";
        public string PipelineUrl { get; } = "00000000.0";

        public string ShortGitHash => GitHash.Count() >= 6 ? GitHash.Substring(0, 6) : "000000";
        public string RepoLink => $"<a href=\"{RepoUrl}\">{ShortGitHash}</a>";
        public string PipelineLink => $"<a href=\"{PipelineUrl}\">{Version}</a>";
        public string EndpointText => $"Powered by {RuntimeInformation.FrameworkDescription} and deployed from commit {RepoLink} via build {PipelineLink}";
        public string ConsoleText => $"Powered by {RuntimeInformation.FrameworkDescription} and deployed from commit {ShortGitHash} with version {Version}";

        public BuildInfo(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (File.Exists(filePath))
            {
                dynamic jToken = JToken.Parse(File.ReadAllText(filePath));

                Version = jToken.Version ?? Version;
                GitHash = jToken.GitHash ?? GitHash;
                RepoUrl = jToken.RepoUrl ?? RepoUrl;
                PipelineUrl = jToken.PipelineUrl ?? PipelineUrl;
            }

            Console.WriteLine(ConsoleText);
        }
    }
}