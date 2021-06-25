using CSB.Business.Enums;
using System;

namespace CSB.Business.Models
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public EmployeeStatus Status { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
