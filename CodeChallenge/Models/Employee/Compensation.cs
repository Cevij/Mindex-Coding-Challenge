using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Models.Employee
{
    public class Compensation
    {

        /// <summary>
        /// 
        /// </summary>
        [Key]
        public string CompensationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EffectiveDate { get; set; }
    }
}
