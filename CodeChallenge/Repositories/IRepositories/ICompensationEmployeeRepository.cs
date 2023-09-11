using CodeChallenge.Models.Employee;
using System;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public interface ICompensationEmployeeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="compensationEmployee"></param>
        /// <returns></returns>
        Compensation AddCompensationEmployee(Compensation compensationEmployee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Compensation GetCompensationEmployeeById(String id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Compensation Remove(Compensation employee);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}