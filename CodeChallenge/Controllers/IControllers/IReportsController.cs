using System;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers.IController
{
    public interface IReportsController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetReportsById(String id);
    }
}
