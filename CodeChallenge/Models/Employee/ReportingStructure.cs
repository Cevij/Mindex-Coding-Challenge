using System.Linq;

namespace CodeChallenge.Models.Employee
{
    public class ReportingStructure
    {
        public Employee Employee { get; set; }

        /// <summary>
        /// Total number of reports under a given employee
        /// </summary>
        public int NumberOfReports => Employee?.DirectReports != null && Employee.DirectReports.Any() ? Employee.DirectReports.Count : 0;
    }
}
