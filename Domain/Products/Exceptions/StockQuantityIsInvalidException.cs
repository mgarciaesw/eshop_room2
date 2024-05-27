﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Exceptions
{
    public sealed class StockQuantityIsInvalidException()
        : Exception("The product name is invalid");
}
