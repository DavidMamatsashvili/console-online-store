using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Dto;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using console_online_store.Services.Interfaces;

namespace console_online_store.Services.Implementations
{
    public class CartService : ICartService
    {
        public readonly ICartRepository _cartRepository;
        public readonly IProductRepository _productRepository;
        public CartService(ICartRepository cartrepo, IProductRepository productrepo)
        {
            _cartRepository = cartrepo;
            _productRepository = productrepo;
        }

        public async Task<Cart> CreateCart(int userid)
        {
            if (userid <= 0) return null;
            Cart? cart = await _cartRepository.CreateCart(userid);
            return cart;
        }
        public async Task<Cart> GetCartById(int cartid)
        {
            if (cartid <= 0) return null;
            Cart? cart = await _cartRepository.GetCartById(cartid);

            if (cart == null) return null;
            return cart;
        }
        public async Task<IEnumerable<CartItem>> GetAllProductsFromCart(int id)
        {
            if (id <= 0) return null;

            IEnumerable<CartItem>? items = await _cartRepository.GetAllProductsFromCart(id);
            if (items == null) return null;
            return items;
        }
        public async Task<Cart> AddProduct(int cartId, int productId)
        {
            if (cartId <= 0 || productId <= 0) return null;
            bool checkCart = await _cartRepository.CheckIfCartExists(cartId);
            bool checkProduct = await _productRepository.CheckIfProductExists(productId);
            bool checkIfCartHasThisProduct = await _cartRepository.CheckIfCartHasThisProduct(cartId, productId);

            if (!checkCart || !checkProduct || checkIfCartHasThisProduct) return null;

            Cart? cart = await _cartRepository.AddProduct(cartId, productId);
            if (cart == null) return null;
            return cart;
        }
        public async Task<Cart> RemoveProduct(int cartId, int cartItemId)
        {
            if (cartId <= 0 || cartItemId <= 0) return null;
            Cart? cart = await _cartRepository.RemoveProduct(cartId, cartItemId);
            if (cart == null) return null;
            return cart;
        }
        public async Task<CartItem> EditCartItem(int cartId, int cartItemId, CartItemDto cartitem)
        {
            bool exists = await _cartRepository.CheckIfCartItemExists(cartId, cartItemId);

            if (!exists) return null;

            CartItem updatedItem = await _cartRepository.EditCartItem(cartId, cartItemId, cartitem);

            return updatedItem;
        }
        public async Task<bool> CheckIfCartHasThisProduct(int cartId, int productId)
        {
            if (cartId <= 0 || productId <= 0) return false;
            bool productExists = await _productRepository.CheckIfProductExists(productId);
            bool checkIfCartExists = await _cartRepository.CheckIfCartExists(cartId);
            if (!productExists || checkIfCartExists) return false;

            bool checkIfCartHasThisProduct = await _cartRepository.CheckIfCartHasThisProduct(cartId, productId);

            if (!checkIfCartHasThisProduct) return false;
            return true;
        }
        public async Task<bool> CheckIfCartExists(int cartId)
        {
            if (cartId <= 0) return false;
            bool exists = await _cartRepository.CheckIfCartExists(cartId);
            if (!exists) return false;
            return true;
        }
        public async Task<bool> CheckIfCartItemExists(int cartId, int itemId)
        {
            if (cartId <= 0 || itemId <= 0) return false;

            bool productExists = await _productRepository.CheckIfProductExists(itemId);
            bool checkIfCartExists = await _cartRepository.CheckIfCartExists(cartId);
            if (!productExists || checkIfCartExists) return false;

            bool checkIfCartItemExists = await _cartRepository.CheckIfCartItemExists(cartId, itemId);
            if (!checkIfCartItemExists) return false;
            return true;
        }
        public async Task<decimal> GetTotalAmount(int cartId)
        {
            if (cartId <= 0) return 0;
            decimal total = await _cartRepository.GetTotalAmount(cartId);
            return total;
        }
    }
}
