using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;

namespace CSB.Repository
{
    public static class BaseEntityExtensions
    {
        //public void M<T>(T? item) where T : struct { }
        public static int GetNewId <T> (this List<T > collection ) where T : BaseEntity
        {
            int newId = collection.Max(x => x.Id);

            return newId + 1;
        }
    }
}
