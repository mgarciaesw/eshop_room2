namespace Domain.Customer;

public sealed record LastName
{
    public string Value { get; set; }
    public const int MinimunLength = 5;
    private LastName(string value) => Value = value;

    public static LastName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MinimunLength)
        {
            throw new ArgumentNullException();
        }

        if (value.Length < MinimunLength)
        {
            throw new ArgumentOutOfRangeException();
        }

        return new LastName(value);
    }
}