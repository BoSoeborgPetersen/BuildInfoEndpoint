using System.IO;
using System.Text;
using Xunit;

namespace BuildInfoEndpoint.Tests;

public class BuildInfoTests
{
    const string testJson = "{ \"GitHash\": \"aaf4c61ddcc5e8a2dabede0f3b482cd9aea9434d\", \"Version\": \"1.2.3\", \"RepoUrl\": \"https://example.com/aaf4c61ddcc5e8a2dabede0f3b482cd9aea9434d\", \"PipelineUrl\": \"https://example.com/aaf4c61ddcc5e8a2dabede0f3b482cd9aea9434d\" }";

    [Fact]
    public void NewBuidInfo_ShouldBeAbleToReadConsoleText()
    {
        // Arrange + Act
        BuildInfo buildinfo = new();

        // Assert
        Assert.NotNull(buildinfo.ConsoleText);
    }

    [Fact]
    public void NewBuidInfo_ShouldBeAbleToReadEndpointText()
    {
        // Arrange + Act
        BuildInfo buildinfo = new();

        // Assert
        Assert.NotNull(buildinfo.EndpointText);
    }


    [Fact]
    public void NewBuidInfo_ShouldBeAbleToReadShortGitHash()
    {
        // Arrange + Act
        BuildInfo buildinfo = new();

        // Assert
        Assert.NotNull(buildinfo.ShortGitHash);
    }

    [Fact]
    public void NewBuidInfo_ShouldBeAbleToReadRepoLink()
    {
        // Arrange + Act
        BuildInfo buildinfo = new();

        // Assert
        Assert.NotNull(buildinfo.RepoLink);
    }

    [Fact]
    public void NewBuidInfo_ShouldBeAbleToReadPipelineLink()
    {
        // Arrange + Act
        BuildInfo buildinfo = new();

        // Assert
        Assert.NotNull(buildinfo.PipelineLink);
    }

    [Fact]
    public void BuildInfo_ReadFromStream_ShouldNotBeNull()
    {
        // Arrange
        var jsonBytes = Encoding.UTF8.GetBytes(testJson);
        var stream = new MemoryStream(jsonBytes);

        // Act
        var buildInfo = BuildInfo.ReadFromStream(stream);

        // Assert
        Assert.NotNull(buildInfo);
    }

    [Fact]
    public void BuildInfo_ReadFromStream_GitHashShouldNotBeNull()
    {
        // Arrange
        var jsonBytes = Encoding.UTF8.GetBytes(testJson);
        var stream = new MemoryStream(jsonBytes);

        // Act
        var buildInfo = BuildInfo.ReadFromStream(stream);

        // Assert
        Assert.NotNull(buildInfo?.GitHash);
    }

    [Fact]
    public void BuildInfo_ReadFromStream_VersionShouldNotBeNull()
    {
        // Arrange
        var jsonBytes = Encoding.UTF8.GetBytes(testJson);
        var stream = new MemoryStream(jsonBytes);

        // Act
        var buildInfo = BuildInfo.ReadFromStream(stream);

        // Assert
        Assert.NotNull(buildInfo?.Version);
    }

    [Fact]
    public void BuildInfo_ReadFromStream_RepoUrlShouldNotBeNull()
    {
        // Arrange
        var jsonBytes = Encoding.UTF8.GetBytes(testJson);
        var stream = new MemoryStream(jsonBytes);

        // Act
        var buildInfo = BuildInfo.ReadFromStream(stream);

        // Assert
        Assert.NotNull(buildInfo?.RepoUrl);
    }

    [Fact]
    public void BuildInfo_ReadFromStream_PipelineUrlShouldNotBeNull()
    {
        // Arrange
        var jsonBytes = Encoding.UTF8.GetBytes(testJson);
        var stream = new MemoryStream(jsonBytes);

        // Act
        var buildInfo = BuildInfo.ReadFromStream(stream);

        // Assert
        Assert.NotNull(buildInfo?.PipelineUrl);
    }
}
