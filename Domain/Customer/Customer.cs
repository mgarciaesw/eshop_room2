using Domain.Primitives;

namespace Domain.Customer
{
    public sealed class Customer : AggregateRoot
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Email Email { get; set; }

        private Customer(Guid id, FirstName firstName, LastName lastName, Email email) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public static Customer Create(FirstName firstName, LastName lastname, Email email)
        {
            var guid = Guid.NewGuid();
            var customer = new Customer(guid, firstName, lastname, email);
            return customer;
        }
    }
}
