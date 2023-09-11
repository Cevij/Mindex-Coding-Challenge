using System;

namespace CodeChallenge.Models.Employee
{
    public class Compensation
    {
        /// <summary>
        /// 
        /// </summary>
        public string CompensationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Salary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EffectiveDate { get; set; }
    }
}
