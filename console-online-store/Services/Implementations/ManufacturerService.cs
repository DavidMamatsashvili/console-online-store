using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Models;
using console_online_store.Repository.Interfaces;

namespace console_online_store.Services.Implementations
{
    public class ManufacturerService : IManufacturerRepository
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<Manufacturer> GetManufacturerByManufacturerId(int id)
        {
            if (id <= 0) return null;
            Manufacturer? manufacturer = await _manufacturerRepository.GetManufacturerByManufacturerId(id);
            return manufacturer;
        }
    }
}
