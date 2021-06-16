using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;

namespace CSB.Business.Interfaces
{
    interface IAddressService
    {
        Task<Address> GetAddressesByIdAsync(int employeeId);
    }
}
