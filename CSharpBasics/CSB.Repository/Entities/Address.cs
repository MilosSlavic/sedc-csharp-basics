using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int PostalCode { get; set; }

    }
}
