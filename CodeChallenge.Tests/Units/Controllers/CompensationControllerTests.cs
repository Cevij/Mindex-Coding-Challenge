using System.Net;
using System.Net.Http;
using System.Text;
using CodeChallenge.Models.Employee;
using CodeCodeChallenge.Tests.Integration.Extensions;
using CodeCodeChallenge.Tests.Integration.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenge.Tests.Integration.Units.Controllers
{
    [TestClass]
    public class CompensationControllerTests
    {
        private static HttpClient _httpClient;
        private static TestServer _testServer;

        [ClassInitialize]
        // Attribute ClassInitialize requires this signature
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static void InitializeClass(TestContext context)
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
        public void CreateCompensationEmployee_Returns_NotFound()
        {
            // Arrange
            var employee = new Compensation()
            {
                Employee = new Employee()
                {
                    EmployeeId = "55a596ae-edd3-4847-99fe-c4518e82c86f",
                    Department = "Complaints",
                    FirstName = "Debbie",
                    LastName = "Downer",
                    Position = "Receiver",
                },
                Salary = 110000.00,
                EffectiveDate = new System.DateTime()
            };

            var requestContent = new JsonSerialization().ToJson(employee);

            // Execute
            var postRequestTask = _httpClient.PostAsync("api/compensation",
               new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var response = postRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void CreateCompensationEmployee_Returns_Created()
        {
            // Arrange
            var expectedEmployeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f";
            var expectedSalary = 11000000.00;
            var expectedEffectiveDate = new System.DateTime();
            var employee = new Compensation()
            {
                Employee = new Employee()
                {
                    EmployeeId = expectedEmployeeId,
                    FirstName = "John",
                    LastName = "Lennon",
                    Position = "Development Manager",
                    Department = "Engineering",
                },
                Salary = expectedSalary,
                EffectiveDate = expectedEffectiveDate
            };

            var requestContent = new JsonSerialization().ToJson(employee);

            // Execute
            var postRequestTask = _httpClient.PostAsync("api/compensation",
               new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var response = postRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            var newEmployee = response.DeserializeContent<Compensation>();
            Assert.IsNotNull(newEmployee.Employee.EmployeeId);
            Assert.AreEqual(expectedEmployeeId, newEmployee.Employee.EmployeeId);
            Assert.AreEqual(expectedSalary, newEmployee.Salary);
            Assert.AreEqual(expectedEffectiveDate, newEmployee.EffectiveDate);
        }

        [TestMethod]
        public void GetEmployeeById_Returns_Ok()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f";
            var expectedFirstName = "John";
            var expectedLastName = "Lennon";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var employee = response.DeserializeContent<Compensation>();
            Assert.AreEqual(expectedFirstName, employee.Employee.FirstName);
            Assert.AreEqual(expectedLastName, employee.Employee.LastName);
        }

        [TestMethod]
        public void GetEmployeeById_Returns_NotFound()
        {
            // Arrange
            var employeeId = "547596ae-edd3-4847-99fe-c4518e82c86f";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/compensation/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
