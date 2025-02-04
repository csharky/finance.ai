using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Tests.Finance.Ai.Domain.ValueObjects;

public class ResultGenericTests
{
    [Fact]
    public void Success_ShouldReturnSuccessfulResultWithValue()
    {
        // Arrange
        var value = 42;

        // Act
        var result = Result<int>.Success(value);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.Value);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Fail_ShouldReturnFailedResultWithErrorMessage()
    {
        // Arrange
        var errorMessage = "An error occurred";

        // Act
        var result = Result<int>.Fail(errorMessage);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(errorMessage, result.Error);
    }

    [Fact]
    public void Fail_ShouldHandleNullErrorMessage()
    {
        // Act
        var result = Result<string>.Fail(null);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Null(result.Value);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Success_ShouldAllowReferenceTypeValue()
    {
        // Arrange
        var value = "Success";

        // Act
        var result = Result<string>.Success(value);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.Value);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Success_ShouldHandleNullableValues()
    {
        // Act
        var result = Result<string?>.Success(null);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Null(result.Value);
        Assert.Null(result.Error);
    }
}