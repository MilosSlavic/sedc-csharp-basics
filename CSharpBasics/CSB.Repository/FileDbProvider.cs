﻿using CSB.Repository.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CSB.Repository
{
    public class FileDbProvider
    {
        private const string employeeFile = "employee.json";

        public static FileDbProvider Instance { get; }

        public List<Employee> Employees { get; set; }

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
            var content = JsonSerializer.Serialize(Employees);
            File.WriteAllText(employeeFile, content);
        }
    }
}
