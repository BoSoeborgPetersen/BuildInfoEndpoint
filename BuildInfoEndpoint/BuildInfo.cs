using System;
using System.IO;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace BuildInfoEndpoint;

public class BuildInfo
{
    public string Version { get; init; } = "0.0.0";
    public string GitHash { get; init; } = "000000";
    public string? RepoUrl { get; init; }
    public string? PipelineUrl { get; init; }

    public string ShortGitHash => GitHash.Length >= 6 ? GitHash[..6] : GitHash;
    public string RepoLink => IsValidUri(RepoUrl) ? $"<a href=\"{RepoUrl}\">{ShortGitHash}</a>" : ShortGitHash;
    public string PipelineLink => IsValidUri(PipelineUrl) ? $"<a href=\"{PipelineUrl}\">{Version}</a>" : Version;
    public string EndpointText => $"Powered by {RuntimeInformation.FrameworkDescription} and deployed from commit {RepoLink} via build {PipelineLink}";
    public string ConsoleText => $"Powered by {RuntimeInformation.FrameworkDescription} and deployed from commit {ShortGitHash} with version {Version}";

    private bool IsValidUri(string? uri)
    {
        return Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out _);
    }

    public static BuildInfo ReadFromFile(string fileName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        BuildInfo? buildInfo = null;

        if (File.Exists(filePath))
        {
            using var stream = File.OpenRead(filePath);
            buildInfo = ReadFromStream(stream);
            Console.WriteLine(buildInfo?.ConsoleText);
        }

        return buildInfo ?? new();
    }

    internal static BuildInfo? ReadFromStream(Stream stream)
    {
        return JsonSerializer.Deserialize<BuildInfo>(stream);
    }
}
