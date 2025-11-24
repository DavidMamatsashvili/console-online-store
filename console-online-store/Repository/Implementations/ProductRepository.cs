using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace console_online_store.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;
        public ProductRepository(StoreDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> products = await _dbContext.Products.ToListAsync();
            return products;
        }
        public async Task<Product> GetProductById(int id)
        {
            Product? product = await _dbContext.Products.FindAsync(id);
            return product;
        }
        public async Task<Product> AddProduct(ProductDto product)
        {
            Product newproduct = new Product()
            {
                UnitPrice = product.UnitPrice,
                Stock = product.Stock,
                Description = product.Description,
            };
            _dbContext.Products.Add(newproduct);
            await _dbContext.SaveChangesAsync();
            return newproduct;
        }
        public async Task<bool> UpdateProduct(int id, ProductDto product)
        {
            Product? old = await _dbContext.Products.FindAsync(id);
            old.UnitPrice = product.UnitPrice;
            old.Stock = product.Stock;
            old.Description = product.Description;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            Product? product = await _dbContext.Products.FindAsync(id);
            if (product == null) return false;
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CheckIfProductExists(int id)
        {
            Product? product = await _dbContext.Products.FindAsync(id);
            if (product == null) return false;
            return true;
        }
        public async Task<Manufacturer> GetProductManufacturerById(int id)
        {
            Manufacturer? manufacturer = await _dbContext.Manufacturers.SingleOrDefaultAsync(x => x.Id == id);
            return manufacturer;
        }
        public async Task<ProductTitle> GetProductTitleById(int id)
        {
            ProductTitle? title = await _dbContext.ProductTitles.SingleOrDefaultAsync(x => x.Id == id);
            return title;
        }
    }
}
