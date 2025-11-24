using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Data;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;

namespace console_online_store.Repository.Implementations
{
    public class ProductTitleRepository : IProductTitleRepository
    {
        private readonly StoreDbContext _dbContext;
        public ProductTitleRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductTitle> GetProductTitleByTitleId(int id)
        {
            ProductTitle? title = await _dbContext.ProductTitles.FindAsync(id);
            return title;
        }
    }

}
