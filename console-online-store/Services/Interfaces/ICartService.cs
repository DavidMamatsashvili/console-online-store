using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;

namespace console_online_store.Services.Interfaces
{
    public interface ICartService
    {
        Task<Cart> GetCartById(int cartid);
        Task<IEnumerable<CartItem>> GetAllProductsFromCart(int id);
        Task<Cart> AddProduct(int cartId, int productId);
        Task<Cart> RemoveProduct(int cartId, int cartItemId);
        Task<CartItem> EditCartItem(int cartId, int cartItemId, CartItemDto cartitem);
    }
}
