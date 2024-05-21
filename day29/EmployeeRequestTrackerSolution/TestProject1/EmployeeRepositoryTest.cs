﻿using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Repositories;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest
{
    public class EmployeeRepositoryTest
    {
        DbContextOptionsBuilder optionsBuilder;

        [SetUp]
        public void Setup()
        {
            optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("EmployeeTest");
        }
        
        [Test]
        public void GetEmployeeTest()
        {
            RequestTrackerContext context = new RequestTrackerContext(optionsBuilder.Options);
            //Arrange
            IReposiroty<int, Employee> employeeRepo = new EmployeeRepository(context);
            employeeRepo.Add(new Employee
            {
                Id = 101,
                Name = "Test1",
                DateOfBirth = new DateTime(2002, 12, 12),
                Phone = "9988776655",
                Role = "Admin",
                Image = ""
            });
            IEmployeeService employeeService = new EmployeeBasicService(employeeRepo);

            //Action
            var result = employeeService.GetEmployeeByPhone("9988776655");

            //Assert
            Assert.IsNotNull(result);

        }

    }
}
