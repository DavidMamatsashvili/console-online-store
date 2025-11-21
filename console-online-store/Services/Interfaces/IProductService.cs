using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;

namespace console_online_store.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<ProductDto> AddProduct(ProductDto product);
        Task<ProductDto> UpdateProduct(int id, ProductDto product);
        Task<bool> DeleteProduct(int id);
    }
}
