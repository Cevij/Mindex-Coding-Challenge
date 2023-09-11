using CodeChallenge.Models.Employee;

namespace CodeChallenge.Services.IServices
{
    public interface IEmployeeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Compensation getCompensationEmployeeById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Employee Create(Employee employee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Compensation CreateCompensationEmployee(Compensation employee);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalEmployee"></param>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        Compensation ReplaceCompensation(Compensation originalEmployee, Compensation newEmployee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalEmployee"></param>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        Employee Replace(Employee originalEmployee, Employee newEmployee);
    }
}
