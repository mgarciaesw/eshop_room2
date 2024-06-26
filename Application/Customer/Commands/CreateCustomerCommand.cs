﻿using Domain.Customer;

namespace Application.Customer.Commands;

public sealed record CreateCustomerCommand(string FirstName, string LastName, string Email, string ShippingAddress);

