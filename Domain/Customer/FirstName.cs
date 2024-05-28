namespace Domain.Customer;

public sealed record FirstName
{
    public string Value { get; init; }
    public const int MinimumLength = 5;
    private FirstName(string value) => Value = value;

    public static FirstName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MinimumLength)
        {
            throw new ArgumentNullException();
        }

        if (value.Length < MinimumLength)
        {
            throw new ArgumentOutOfRangeException();
        }

        return new FirstName(value);
    }
}
