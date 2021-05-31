using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using CSB.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Interfaces
{
    internal interface IPhoneRepository : IPhoneRepository<Phone>
    {
        List<Phone> GetByName(string name);
    }
}
