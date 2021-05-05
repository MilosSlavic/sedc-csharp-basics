using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public short Status { get; set; }
        public short Gender { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        // TODO: Position 
    }
}
