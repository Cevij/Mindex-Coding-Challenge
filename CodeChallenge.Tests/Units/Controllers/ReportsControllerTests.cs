
using System.Net;
using System.Net.Http;
using CodeChallenge.Models.Employee;
using CodeCodeChallenge.Tests.Integration.Extensions;
using CodeCodeChallenge.Tests.Integration.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenge.Tests.Integration.Units.Controllers
{
    [TestClass]
    public class ReportsControllerTests
    {
        private static HttpClient _httpClient;
        private static TestServer _testServer;

        [ClassInitialize]
        // Attribute ClassInitialize requires this signature
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public void InitializeClass(TestContext context)
        {
            _testServer = new TestServer();
            _httpClient = _testServer.NewClient();
        }

        [ClassCleanup]
        public static void CleanUpTest()
        {
            _httpClient.Dispose();
            _testServer.Dispose();
        }

        [TestMethod]
        public void Get_Employee_ReportingStructure_By_EmployeeId()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f";
            var expectedFirstName = "John";
            var expectedLastName = "Lennon";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reports/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            var reportEmployee = response.DeserializeContent<ReportingStructure>();
            Assert.IsNotNull(reportEmployee.Employee);
            Assert.AreEqual(expectedFirstName, reportEmployee.Employee.FirstName);
            Assert.AreEqual(expectedLastName, reportEmployee.Employee.LastName);
            Assert.AreEqual(1, reportEmployee.NumberOfReports);
        }

        [TestMethod]
        public void Get_Employee_ReportingStructure_Returns_Ok()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f";
            var expectedFirstName = "John";
            var expectedLastName = "Lennon";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reports/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var reportingEmployee = response.DeserializeContent<ReportingStructure>();
            Assert.AreEqual(expectedFirstName, reportingEmployee.Employee.FirstName);
            Assert.AreEqual(expectedLastName, reportingEmployee.Employee.LastName);
        }

        [TestMethod]
        public void Get_Employee_ReportingStructure_Returns_NotFound()
        {
            // Arrange
            var employeeId = "76a596ae-edd3-4847-99fe-c4518e82c86f";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reports/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
