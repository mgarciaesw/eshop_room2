using System.Data;

namespace Domain.Customer;

public sealed record ShippingAddress()
{
    public string Value { get; set; }
    private ShippingAddress(string value) => Value = value;

    public static ShippingAddress Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new NoNullAllowedException();
        }

        return new ShippingAddress(value);
    }
}