using Finance.Ai.Domain.ValueObjects;

namespace Finance.Ai.Tests.Finance.Ai.Domain.ValueObjects;

public class EmailTests
{
    [Fact] // Test a valid email
    public void Create_ValidEmail_ReturnsEmailValueObject()
    {
        // Arrange
        var validEmail = "test@example.com";

        // Act
        var email = Email.Create(validEmail);

        // Assert
        Assert.NotNull(email);
        Assert.Equal(validEmail, email.Value);
    }

    [Fact] // Test an invalid email
    public void Create_InvalidEmail_ThrowsArgumentException()
    {
        // Arrange
        var invalidEmail = "invalid-email";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => Email.Create(invalidEmail));
        Assert.Equal($"Invalid email format: {invalidEmail}. (Parameter 'email')", exception.Message);
    }

    [Theory] // Test multiple invalid emails
    [InlineData(null)]
    [InlineData("")]
    [InlineData("plainaddress")]
    [InlineData("@missingusername.com")]
    [InlineData("missingatsymbol.com")]
    [InlineData("invalid@.com")]
    public void Create_InvalidEmailFormats_ThrowsArgumentException(string invalidEmail)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Email.Create(invalidEmail));
    }

    [Fact] // Email comparison (Equality check for Value Object behavior)
    public void TwoEmails_WithSameValue_AreEqual()
    {
        // Arrange
        var email1 = Email.Create("test@example.com");
        var email2 = Email.Create("test@example.com");

        // Act & Assert
        Assert.Equal(email1, email2); // Value objects are equal if their values are the same
    }

    [Fact] // Email inequality
    public void TwoEmails_WithDifferentValues_AreNotEqual()
    {
        // Arrange
        var email1 = Email.Create("test1@example.com");
        var email2 = Email.Create("test2@example.com");

        // Act & Assert
        Assert.NotEqual(email1, email2);
    }

}