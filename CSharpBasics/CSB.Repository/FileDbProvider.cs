using CSB.Repository.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CSB.Repository
{
    public class FileDbProvider
    {
        private const string employeeFile = "employee.json";

        private const string phoneFile = "phone.json";

        public static FileDbProvider Instance { get; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Phone> Phones { get; set; } = new List<Phone>();

        static FileDbProvider()
        {
            Instance = new FileDbProvider();
        }

        private FileDbProvider()
        {
            Load();
        }

        public void Load()
        {
            if (!File.Exists(employeeFile))
            {
                File.Create(employeeFile);
            }

            var content = File.ReadAllText(employeeFile);

            if (!string.IsNullOrEmpty(content))
            {
                var employeesDeserialized = JsonSerializer.Deserialize<IEnumerable<Employee>>(content);
                Employees.Clear();
                Employees.AddRange(employeesDeserialized);
            }
        }

        public void Save()
        {
            var employeesContent = JsonSerializer.Serialize(Employees);
            File.WriteAllText(employeeFile, employeesContent);

            var phonesContent = JsonSerializer.Serialize(Phones);
            File.WriteAllText(phoneFile, phonesContent);
        }
    }
}
