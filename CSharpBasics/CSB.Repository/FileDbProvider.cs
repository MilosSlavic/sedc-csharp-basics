using CSB.Repository.Entities;
using System.Collections;
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

        private const string addressFile = "address.json";

        public static FileDbProvider Instance { get; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Phone> Phones { get; set; } = new List<Phone>();

        public List<Address> Addresses { get; set; } = new List<Address>();

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
            var employeeContent = ReadFile(employeeFile);
            var phonesContent = ReadFile(phoneFile);
            var adressContent = ReadFile(addressFile);

            LoadContent<Employee>(Employees, employeeContent);
            LoadContent(Phones, phonesContent);
            LoadContent(Addresses, adressContent);

            
        }

        public string ReadFile (string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return File.ReadAllText(filePath);
        }

        public void LoadContent <T>(List<T> collection, string content)
        {

            if (!string.IsNullOrEmpty(content))
            {
                var contentDeserialized = JsonSerializer.Deserialize<IEnumerable<T>>(content);
                collection.Clear();
                collection.AddRange(contentDeserialized);
            }
        }

        public void Save()
        {
            var employeesContent = JsonSerializer.Serialize(Employees);
            File.WriteAllText(employeeFile, employeesContent);

            var phonesContent = JsonSerializer.Serialize(Phones);
            File.WriteAllText(phoneFile, phonesContent);

            var addressContent = JsonSerializer.Serialize(Addresses);
            File.WriteAllText(addressFile, addressContent);
        }
    }
}
