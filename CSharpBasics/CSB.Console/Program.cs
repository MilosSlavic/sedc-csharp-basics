using CSB.Business;
using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Repository;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using cli = System.Console;

namespace CSB.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEmployeeRepository repositoryImpl = ImplementationProvider.GetEmployeeRepositoryImpl();
            //cli.WriteLine(repositoryImpl.GetType());

            //IEmployeeService employeeService = new EmployeeService(repositoryImpl);
            //var innerEx = new Exception("ex message");
            //var ex = new ArgumentException("invalid argument", "Id");

            //var employee = new Employee(123, "pera", "peric", 15, "m@s.com")
            //{
            //    Email = "pera@outlook.com",
            //};


            //cli.WriteLine("Last email: " + employee.Email);

            // StackOverflow(1);

            //HighMemoryConsumption();


        }

        static void StackOverflow(int i)
        {
            i++;
            StackOverflow(i);
        }

        static void HighMemoryConsumption()
        {
            var list = new List<List<Employee>>();
            while (true)
            {
                list.Add(HighMemory());
            }
        }

        static List<Employee> HighMemory()
        {
            var list = new List<Employee>();
            int i = 0;
            while (i < 1000000)
            {
                cli.WriteLine(i);
                list.Add(new Employee
                {
                    Id = i,
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Gender = 1,
                    DateOfBirth = DateTime.Now,
                    Email = "Email@email.com",
                    Position = new Position
                    {
                        Id = 1,
                        Code = "Asd",
                        Description = "Asd",
                        Name = "asd"
                    },
                    Status = 3
                });
                i++;
            }
            return list;
        }

        void UseDI()
        {
            var services = new ServiceCollection();
            services.AddRepository();
            services.AddBusiness();
            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            var employeeService = scope.ServiceProvider.GetRequiredService<IEmployeeService>();
            try
            {
                var employee = employeeService.GetById(123);
            }
            catch (NotFoundException nfEx)
            {
                // ... 404
            }
            catch(Exception ex)
            {
            }
        }
    }
}
