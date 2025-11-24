using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.MenuCore;
using console_online_store.Models;
using console_online_store.Services.Implementations;

namespace console_online_store.Controllers
{
    public class ProductController
    {
        public MenuContext _context;
        public ProductService _productService;
        public ProductController(MenuContext context, ProductService service)
        {
            _context = context;
            _productService = service;
        }

        public async Task ShowAllProducts()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Products in the store:");
            IEnumerable<Product> products = await _productService.GetAllProducts();
            foreach (Product product in products)
            {
                Manufacturer manufacturer = await _productService.GetProductManufacturerById(product.ManufacturerId);
                ProductTitle title = await _productService.GetProductTitleById(product.ProductTitleId);
                Console.WriteLine($"{product.Id}. Title:{title.ProductTitle1} Price:{product.UnitPrice} Description:{product.Description} Stock:{product.Stock} Manufacturer:{manufacturer.ManufacturerName}");
            }
        }

        public async Task EditProductList()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Enter an Id of a product:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a new price:");
            decimal newprice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter new stock amount:");
            int stockamount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write Description of a product:");
            string? description = Console.ReadLine();

            ProductDto productDto = new ProductDto()
            {
                UnitPrice = newprice,
                Stock = stockamount,
                Description = description
            };

            ProductDto? updated = await _productService.UpdateProduct(id, productDto);
            if (updated != null)
            {
                Console.WriteLine("Product sucessfuly updated");
                _context.showAdminMenu = true;
            }
            else
            {
                Console.WriteLine("error ocurred during updating product");
                return;
            }
        }
    }
}
