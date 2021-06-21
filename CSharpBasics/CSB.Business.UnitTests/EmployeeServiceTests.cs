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
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSB.Business.UnitTests
{
    public class EmployeeServiceTests
    {/*public async Task<GetEmployeeDto> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee is null)
            {
                throw new NotFoundException(nameof(Employee));
            }

            return _mapper.Map<GetEmployeeDto>(employee);
        }*/

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
        /* public async Task<IReadOnlyCollection<GetEmployeeDto>> GetAllAsync()
         {
             var employees = await _employeeRepository.GetAllAsync();
             if (employees.Any() == false)
             {
                 throw new NotFoundException(nameof(Employee));
             }

             return _mapper.Map<IReadOnlyCollection<GetEmployeeDto>>(employees);
         }*/
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

        /*public async Task<int> CreateAsync(CreateEmployeeDto employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            var entity = _mapper.Map<Employee>(employee);
            return await _employeeRepository.CreateAsync(entity);
        }
        */

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
            CreateEmployeeDto item =new CreateEmployeeDto()
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

        /*public async Task<bool> UpdateAsync(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            return await _employeeRepository.UpdateAsync(employee);
        }*/
        [Fact]
        public async Task UpdateAsync_throws_ArgumentNullException()
        {
            var employeeService = new EmployeeService(_mapper, null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => employeeService.UpdateAsync(null));

        }

        //public async Task UpdateAsync_SuccessAsync()

        /*public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return await _employeeRepository.DeleteAsync(id);
        }
*/
        [Fact]
        public async Task DeleteAsync_throws_ArgumentException()
        {
            var employeeService = new EmployeeService(_mapper, null);
            await Assert.ThrowsAsync<ArgumentException>(() => employeeService.DeleteAsync(0));
        }


        [Fact]
        public async Task DeleteAsync_SuccessAsync()
        {
            var repositoryMock = new Mock<IEmployeeRepository>();
            repositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Repository.Entities.Employee>()
                { new Employee
                    { DateOfBirth = DateTime.Today.AddYears(-18),
                       Email = "mail@mail.com",
                       FirstName = "First",
                       LastName = "Last",
                       Gender = 1,
                       Position = null,
                       Status = 1 
                    },
                    new Employee{ }
                });
            var employeeService = new EmployeeService(_mapper, repositoryMock.Object);
            IReadOnlyCollection<GetEmployeeDto> entities = await employeeService.GetAllAsync();
            var expected = await Task<bool>.FromResult<bool>(true);
            var actual1 = await employeeService.DeleteAsync(1);
            var actual2 = await employeeService.DeleteAsync(2);
            Assert.True(actual1);
            Assert.False(actual2);

        }
    }
}
