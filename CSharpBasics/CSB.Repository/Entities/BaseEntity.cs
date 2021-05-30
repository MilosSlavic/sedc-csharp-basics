using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;

namespace CSB.Repository.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
