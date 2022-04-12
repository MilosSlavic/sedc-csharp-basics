using CSB.Business;
using CSB.Business.Enums;
using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Business.Impl;
using CSB.Repository;
using CSB.Repository.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using cli = System.Console;
using AutoMapper;
using CSB.Repository.Interfaces;
using CSB.Repository.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;

namespace CSB.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Option<string>(
                    "--fName",
                    description: "Employee first name"),
                new Option<string>(
                    "--lName",
                    "Employee last name"),
                new Option<Gender>(
                    "--gender",
                    "Employee gender"),
                new Option<string>(
                    "--dob",
                    "Employee date of birth"),
                new Option<string>(
                    "--email",
                    "Employee email2")
            };

            rootCommand.Description = "My sample app";

            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler
                .Create<string, string, Gender, string, string>(
                async (fName, lName, gender, dob, email) =>
                {
                    Debugger.Launch();
                    IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<BusinessProfile>())
                        .CreateMapper();
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<CbsDbContext>();
                    dbContextOptionsBuilder.UseSqlite("Data Source=file.db");
                    var dbContext = new CbsDbContext(dbContextOptionsBuilder.Options);
                    await dbContext.Database.EnsureCreatedAsync();
                    IEmployeeRepository employeeRepository = new EmployeeRepository(dbContext);
                    IEmployeeService employeeService = new EmployeeService(mapper, employeeRepository);

                    var id = await employeeService.CreateAsync(new Business.Models.CreateEmployeeDto
                    {
                        FirstName = fName,
                        LastName = lName,
                        Gender = gender,
                        Email = email,
                        DateOfBirth = DateTime.ParseExact(dob, "dd.MM.yyyy.", CultureInfo.CurrentCulture)
                    });

                    cli.WriteLine($"Created employee. Id: '{id}'");
                }
            );

            await rootCommand.InvokeAsync(args);

            #region Obnavljanje
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

            //SomeAsync().GetAwaiter().GetResult();
            #endregion
        }

        static Task SomeAsync()
        {
            return Task.CompletedTask;
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
                var employee = employeeService.GetByIdAsync(123);
            }
            catch (NotFoundException nfEx)
            {
                // ... 404
            }
            catch (Exception ex)
            {
            }
        }
    }
}
