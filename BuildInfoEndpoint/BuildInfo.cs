using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace BuildInfoEndpoint
{
    public class BuildInfo
    {
        public string Version { get; } = "0.0.0";
        public string GitHash { get; } = "000000";
        public string RepoUrl { get; }
        public string PipelineUrl { get; }

        public string ShortGitHash => GitHash.Count() >= 6 ? GitHash.Substring(0, 6) : GitHash;
        public string RepoLink => IsValidUri(RepoUrl) ? $"<a href=\"{RepoUrl}\">{ShortGitHash}</a>" : ShortGitHash;
        public string PipelineLink => IsValidUri(PipelineUrl) ? $"<a href=\"{PipelineUrl}\">{Version}</a>" : Version;
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
                RepoUrl = jToken.RepoUrl;
                PipelineUrl = jToken.PipelineUrl;
            }

            Console.WriteLine(ConsoleText);
        }

        private bool IsValidUri(string uri)
        {
            return Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out _);
        }
    }
}