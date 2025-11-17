using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;

namespace console_online_store.Repository.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartItem>> GetAllProductsFromCart(int id);
        Task<Cart> AddProduct(int cartId,int productId);
        Task<Cart> RemoveProduct(int cartId, int cartItemId);
    }
}
