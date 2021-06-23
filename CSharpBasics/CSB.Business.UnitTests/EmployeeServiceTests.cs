using AutoMapper;
using CSB.Business.Enums;
using CSB.Business.Exceptions;
using CSB.Business.Impl;
using CSB.Business.Models;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSB.Business.UnitTests
{
    public class EmployeeServiceTests
    {
        private readonly IMapper _mapper;

        public EmployeeServiceTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile<BusinessProfile>()).CreateMapper();
        }

        [Fact]
        public async Task GetByIdAsync_throws_ArgumentNullException()
        {
            var employeeService = new EmployeeService(_mapper, null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => employeeService.GetByIdAsync(0));
        }

        [Fact]
        public async Task GetByIdAsync_throws_NotFoundException()
        {
            var repositoryMock = new Mock<IEmployeeRepository>();
            var employeeService = new EmployeeService(_mapper, repositoryMock.Object);
            await Assert.ThrowsAsync<NotFoundException>(() => employeeService.GetByIdAsync(1));
        }

        [Fact]
        public async Task GetByIdAsync_SuccessAsync()
        {
            var repositoryMock = new Mock<IEmployeeRepository>();
            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Repository.Entities.Employee
                {
                    DateOfBirth = DateTime.Today.AddYears(-18),
                    Email = "mail@mail.com",
                    FirstName = "First",
                    LastName = "Last",
                    Gender = 1,
                    Position = null,
                    Status = 1
                });
            var employeeService = new EmployeeService(_mapper, repositoryMock.Object);
            var entity = await employeeService.GetByIdAsync(1);

            Assert.Equal(DateTime.Today.AddYears(-18), entity.DateOfBirth);
            Assert.Equal("mail@mail.com", entity.Email);
            Assert.Equal("First", entity.FirstName);
            Assert.Equal("Last", entity.LastName);
            Assert.Equal(Gender.Male, entity.Gender);
            Assert.Equal(EmployeeStatus.Active, entity.Status);
        }

        [Fact]
        public async Task GetAllByAsync_throws_NotFoundException()
        {
            var repositoryMock = new Mock<IEmployeeRepository>();
            repositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Employee>());
            var employeeService = new EmployeeService(_mapper, repositoryMock.Object);

            await Assert.ThrowsAsync<NotFoundException>(() => employeeService.GetAllAsync());
        }
        [Fact]
        public async Task GetAllByAsync_SuccessAsync()
        {
            var repositoryMock = new Mock<IEmployeeRepository>();
            repositoryMock.Setup(x => x.GetAllAsync())
                    .ReturnsAsync(new List<Repository.Entities.Employee>()
                    { new Employee
                        {
                        DateOfBirth = DateTime.Today.AddYears(-18),
                        Email = "mail@mail.com",
                        FirstName = "First",
                        LastName = "Last",
                        Gender = 1,
                        Position = null,
                        Status = 1
                        },
                       new Employee
                       {
                        DateOfBirth = DateTime.Today.AddYears(-20),
                        Email = "mail.mm@mail.com",
                        FirstName = "FName",
                        LastName = "LName",
                        Gender = 2,
                        Position = null,
                        Status = 1
                        }
                    });
            var employeeService = new EmployeeService(_mapper, repositoryMock.Object);
            IReadOnlyCollection<GetEmployeeDto> entities = await employeeService.GetAllAsync();
            int i = 0;
            {
                Assert.Equal(DateTime.Today.AddYears(-18), entities.ElementAt(i).DateOfBirth);
                Assert.Equal("mail@mail.com", entities.ElementAt(i).Email);
                Assert.Equal("First", entities.ElementAt(i).FirstName);
                Assert.Equal("Last", entities.ElementAt(i).LastName);
                Assert.Equal(Gender.Male, entities.ElementAt(i).Gender);
                Assert.Equal(EmployeeStatus.Active, entities.ElementAt(i).Status);
                i++;
                Assert.Equal(DateTime.Today.AddYears(-20), entities.ElementAt(i).DateOfBirth);
                Assert.Equal("mail.mm@mail.com", entities.ElementAt(i).Email);
                Assert.Equal("FName", entities.ElementAt(i).FirstName);
                Assert.Equal("LName", entities.ElementAt(i).LastName);
                Assert.Equal(Gender.Female, entities.ElementAt(i).Gender);
                Assert.Equal(EmployeeStatus.Active, entities.ElementAt(i).Status);
            }


        }

        [Fact]
        public async Task CreateAsync_throws_ArgumentNullException()
        {
            var employeeService = new EmployeeService(_mapper, null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => employeeService.CreateAsync(null));

        }

        [Fact]
        public async Task CreateAsync_SuccessAsync()
        {
            var repositoryMock = new Mock<IEmployeeRepository>();
            repositoryMock.Setup(x => x.CreateAsync(It.IsAny<Employee>()))
                    .ReturnsAsync(1);
            CreateEmployeeDto item = new CreateEmployeeDto()
            {
                DateOfBirth = DateTime.Today.AddYears(-18),
                Email = "mail@mail.com",
                FirstName = "First",
                LastName = "Last",
                Gender = 0
            };
            var employeeService = new EmployeeService(_mapper, repositoryMock.Object);
            var actualId = await employeeService.CreateAsync(item);
            var expectedId = await Task<int>.FromResult<int>(1);
            Assert.Equal<int>(expectedId, actualId);
        }

        [Fact]
        public async Task UpdateAsync_throws_ArgumentNullException()
        {
            var employeeService = new EmployeeService(_mapper, null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => employeeService.UpdateAsync(null));

        }

        [Fact]
        public async Task DeleteAsync_throws_ArgumentException()
        {
            var employeeService = new EmployeeService(_mapper, null);
            await Assert.ThrowsAsync<ArgumentException>(() => employeeService.DeleteAsync(0));
        }

        [Fact]
        public async Task DeleteAsync_throws_NotFoundException()
        {
            var repositoryMock = new Mock<IEmployeeRepository>();
            var employeeService = new EmployeeService(_mapper, repositoryMock.Object);
            await Assert.ThrowsAsync<NotFoundException>(() => employeeService.DeleteAsync(1));
        }

        [Fact]
        public async Task DeleteAsync_SuccessAsync()
        {
            var repositoryMock = new Mock<IEmployeeRepository>();
            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Employee { });
            repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync(true);
            var employeeService = new EmployeeService(_mapper, repositoryMock.Object);
            var actual = await employeeService.DeleteAsync(1);
            Assert.True(actual);

        }
    }
}
