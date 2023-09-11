using CodeChallenge.Models.Employee;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories.IRepositories
{
    public interface IEmployeeRepository
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
        /// <param name="employee"></param>
        /// <returns></returns>
        Employee Add(Employee employee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Employee Remove(Employee employee);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}