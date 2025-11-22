using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace console_online_store.Repository.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly StoreDbContext _dbContext;
        public CartRepository(StoreDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Cart> GetCartById(int cartid)
        {
            Cart? cart = await _dbContext.Carts.FindAsync(cartid);
            return cart;
        }
        public async Task<IEnumerable<CartItem>> GetAllProductsFromCart(int id)
        {
            IEnumerable<CartItem>? items = await _dbContext.CartItems
                .Where(x => x.CartId==id)
                .ToListAsync();
            return items;
        }
        public async Task<Cart> AddProduct(int cartId, int productId)
        {
            Cart? currentCart = await _dbContext.Carts.FindAsync(cartId);
            Product? product = await _dbContext.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            CartItem? newItem = new CartItem()
            {
                CartId = cartId,
                ProductId = productId,
                UnitPrice = product.UnitPrice,
                Quantity = 1
            };
            currentCart?.CartItems.Add(newItem);
            await _dbContext.SaveChangesAsync();
            return currentCart;
        }
        public async Task<Cart> RemoveProduct(int cartId, int cartItemId)
        {
            Cart? currentCart = await _dbContext.Carts
                .Include(x => x.CartItems)
                .FirstOrDefaultAsync(y => y.Id == cartId);

            if (currentCart == null) return null;

            CartItem? item = currentCart?.CartItems.SingleOrDefault(x => x.Id == cartItemId);
            if (item == null) return null;

            currentCart?.CartItems.Remove(item);
            await _dbContext.SaveChangesAsync();
            return currentCart;
        }
        public async Task<CartItem> EditCartItem(int cartId, int cartItemId, CartItemDto cartitem)
        {
            Cart? cart = await _dbContext.Carts.Include(x => x.CartItems).SingleOrDefaultAsync(x => x.Id == cartId);
            CartItem? item = cart?.CartItems.SingleOrDefault(y => y.Id == cartItemId);
            item.Quantity = cartitem.Quantity;
            await _dbContext.SaveChangesAsync();
            return item;
        }
        public async Task<bool> CheckIfCartExists(int cartid)
        {
            Cart? cart = await _dbContext.Carts.FindAsync(cartid);
            if (cart == null) return false;
            return true;
        }
        public async Task<bool> CheckIfCartHasThisProduct(int cartId, int productId)
        {
            Cart? cart = await _dbContext.Carts.Include(x => x.CartItems).SingleOrDefaultAsync(x => x.Id == cartId);
            CartItem? cartitem = cart.CartItems.SingleOrDefault(x => x.Id == productId);

            if (cartitem == null) return false;
            return true;
        }
        public async Task<bool> CheckIfCartItemExists(int cartId, int cartItemId)
        {
            bool checkcart = await CheckIfCartExists(cartId);
            if (!checkcart) return false;

            Cart? cart = await _dbContext.Carts.Include(x =>x.CartItems).SingleOrDefaultAsync(x =>x.Id == cartId);
            if (cart == null) return false;

            bool exists = cart.CartItems.Any(x => x.Id == cartItemId);
            return exists;
        }
    }
}
