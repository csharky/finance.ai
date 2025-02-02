using System.Text.RegularExpressions;

namespace Finance.Ai.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email must not be null, empty, or whitespace.", nameof(email));
            }

            if (!EmailRegex.IsMatch(email))
            {
                throw new ArgumentException($"Invalid email format: {email}.", nameof(email));
            }

            return new Email(email);
        }

        private static readonly Regex EmailRegex = new(
            @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
            RegexOptions.Compiled);
    }
}