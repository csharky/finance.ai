using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Tests.Finance.Ai.Domain.ValueObjects;

public class ResultTests
{
    [Fact]
    public void Success_ShouldReturnSuccessfulResult()
    {
        // Act
        var result = Result.Success();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Fail_ShouldReturnFailedResult()
    {
        // Arrange
        var errorMessage = "An error occurred";

        // Act
        var result = Result.Fail(errorMessage);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(errorMessage, result.Error);
    }

    [Fact]
    public void Fail_ShouldHandleNullErrorMessage()
    {
        // Act
        var result = Result.Fail(null);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Null(result.Error);
    }
}