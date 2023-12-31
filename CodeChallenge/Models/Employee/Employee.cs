﻿using System;
using System.Collections.Generic;

namespace CodeChallenge.Models.Employee
{
    public class Employee
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public List<Employee> DirectReports { get; set; }
    }
}
