using Xunit;

namespace BuildInfoEndpoint.Tests;

public class BuildInfoTests
{
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
}
