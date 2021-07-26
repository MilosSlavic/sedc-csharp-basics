using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Entities
{
    public class FamilyMember : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

    }
}
