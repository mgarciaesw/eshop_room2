namespace Domain.Customer;

public sealed record LastName
{
    public string Value { get; init; }
    public const int MinimumLength = 5;
    private LastName(string value) => Value = value;

    public static LastName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MinimumLength)
        {
            throw new ArgumentNullException();
        }

        if (value.Length < MinimumLength)
        {
            throw new ArgumentOutOfRangeException();
        }

        return new LastName(value);
    }
}