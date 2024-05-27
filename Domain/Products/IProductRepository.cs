using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task<Product> GetById(Guid id);
        Task Update(Product product);
    }
}
