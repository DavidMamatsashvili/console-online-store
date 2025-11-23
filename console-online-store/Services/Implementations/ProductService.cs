using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Implementations;
using console_online_store.Repository.Interfaces;
using console_online_store.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace console_online_store.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _repo.GetProductById(id);
        }

        public async Task<ProductDto?> AddProduct(ProductDto product)
        {
            if (product == null) return null;

            await _repo.AddProduct(product);
            return product;
        }

        public async Task<ProductDto?> UpdateProduct(int id, ProductDto product)
        {
            if (product == null) return null;

            var existing = await _repo.GetProductById(id);
            if (existing == null) return null;

            await _repo.UpdateProduct(id, product);
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _repo.GetProductById(id);
            if (product == null) return false;

            await _repo.DeleteProduct(id);
            return true;
        }

        public async Task<Manufacturer> GetProductManufacturerById(int id)
        {
            if (id <= 0) return null;
            Manufacturer? manufacturer = await _repo.GetProductManufacturerById(id);
            return manufacturer;
        }
        public async Task<ProductTitle> GetProductTitleById(int id)
        {
            if (id <= 0) return null;
            ProductTitle? title = await _repo.GetProductTitleById(id);
            return title;
        }
    }
}
