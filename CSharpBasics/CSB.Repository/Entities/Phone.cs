using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Entities
{
    public class Phone : BaseEntity
    {
        public int EmployeeId { get; set; }

        public string Number { get; set; }

        public short Type { get; set; }
    }
}
