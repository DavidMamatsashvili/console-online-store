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
        Task<Cart> CreateCart(int userid);
        Task<Cart> GetCartById(int userid);
        Task<IEnumerable<CartItem>> GetAllProductsFromCart(int id);
        Task<Cart> AddProduct(int cartId, int productId);
        Task<Cart> RemoveProduct(int cartId, int cartItemId);
        Task<CartItem> EditCartItem(int cartId, int cartItemId, CartItemDto cartitem);
        Task<bool> CheckIfCartHasThisProduct(int cartId, int productId);
        Task<bool> CheckIfCartExists(int cartId);
        Task<bool> CheckIfCartItemExists(int cartId, int itemId);
        Task<decimal> GetTotalAmount(int cartId);
    }
}
