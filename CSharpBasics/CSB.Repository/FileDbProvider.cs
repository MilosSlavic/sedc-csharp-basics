using CSB.Repository.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CSB.Repository
{
    public static class FileDbProvider
    {
        private const string employeeFile = "employee.json";
        private static List<Employee> Employees { get; set; }
        public static bool AutoSaveOnAdd { get; set; } = true;

        static FileDbProvider()
        {
            Load();
        }

        public static void Load()
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

        public static void Save()
        {
            var content = JsonSerializer.Serialize(Employees);
            File.WriteAllText(employeeFile, content);
        }

        public static IReadOnlyList<Employee> GetAll()
        {
            return Employees;
        }

        public static void Add(Employee employee)
        {
            if (Employees.Any(x => x.ID == employee.ID))
            {
                return;
            }

            Employees.Add(employee);
            if (AutoSaveOnAdd)
            {
                Save();
            }
        }
    }
}
