using System.Linq;

namespace CodeChallenge.Models.Employee
{
    public class ReportingStructure
    {
        /// <summary>
        /// 
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NumberOfReports => Employee?.DirectReports != null && Employee.DirectReports.Any() ? Employee.DirectReports.Count : 0;
    }
}
