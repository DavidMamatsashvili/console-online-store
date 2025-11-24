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
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly StoreDbContext _dbContext;
        public ManufacturerRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Manufacturer> GetManufacturerByManufacturerId(int id)
        {
            Manufacturer? manufacturer = await _dbContext.Manufacturers.FindAsync(id);
            return manufacturer;
        }
    }
}
