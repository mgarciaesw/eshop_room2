namespace Domain.Customer;

public sealed record Email
{
    public string Value { get; set; }
    private Email(string value) => Value = value;

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException();
        }

        return new Email(value);
    }
}