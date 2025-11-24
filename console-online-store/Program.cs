using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.MenuCore;
using console_online_store.Models;
using console_online_store.Repository.Implementations;
using console_online_store.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace console_online_store
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //using StoreDbContext db = new StoreDbContext();
            //CartRepository repo = new CartRepository(db);
            //IEnumerable<CartItem> prd = await repo.GetAllProductsFromCart(1);
            //foreach (CartItem item in prd){
            //    Console.WriteLine(item.UnitPrice);
            //}
            await MainMenu.StartAsync();
        }
    }
}
