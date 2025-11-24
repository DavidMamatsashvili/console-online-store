using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Models;

namespace console_online_store.Repository.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> GetManufacturerByManufacturerId(int id);
    }
}
