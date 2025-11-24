using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;
using console_online_store.Services.Interfaces;

namespace console_online_store.Services.Implementations
{
    public class ProductTitleService : IProductTitleService
    {
        private readonly IProductTitleRepository _productTitleRepository;
        public ProductTitleService(IProductTitleRepository productTitleRepository)
        {
            _productTitleRepository = productTitleRepository;
        }

        public async Task<ProductTitle> GetProductTitleByTitleId(int id)
        {
            if (id <= 0) return null;
            ProductTitle? title = await _productTitleRepository.GetProductTitleByTitleId(id);
            return title;
        }
    }
}
