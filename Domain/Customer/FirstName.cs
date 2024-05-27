namespace Domain.Customer;

public sealed record FirstName()
{
    public string Value { get; set; }
    public const int MinimunLength = 5;
    private FirstName(string value) => Value = value;

    public static FirstName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MinimunLength)
        {
            throw new ArgumentNullException();
        }

        if (value.Length < MinimunLength)
        {
            throw new ArgumentOutOfRangeException();
        }

        return new FirstName(value);
    }
}
