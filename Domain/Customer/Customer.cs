using Domain.Primitives;

namespace Domain.Customer
{
    public sealed class Customer : AggregateRoot
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Email Email { get; set; }
        public ShippingAddress ShippingAddress { get; set; }

        private Customer(Guid id, FirstName firstName, LastName lastName, Email email,  ShippingAddress shippingAddress) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ShippingAddress = shippingAddress;
        }

        public static Customer Create(FirstName firstName, LastName lastname, Email email, ShippingAddress shippingAddress)
        {
            var guid = Guid.NewGuid();
            var customer = new Customer(guid, firstName, lastname, email, shippingAddress);
            return customer;
        }
    }
}
