using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Models.Employee
{
    public class Compensation
    {

        /// <summary>
        /// Primary Key
        /// </summary>
        public string CompensationId { get; set; }

        public Employee Employee { get; set; }

        public double Salary { get; set; }

        public DateTime EffectiveDate { get; set; }
    }
}
