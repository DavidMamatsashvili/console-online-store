using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;

namespace console_online_store.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(ProductDto product);
        Task<bool> UpdateProduct(int id, ProductDto product);
        Task<bool> DeleteProduct(int id);
        Task<bool> CheckIfProductExists(int id);
        Task<Manufacturer> GetProductManufacturerById(int id);
        Task<ProductTitle> GetProductTitleById(int id);
    }
}
