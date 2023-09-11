using System;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers.IController
{
    public interface IReportsController
    {
        public IActionResult GetReportsById(String id);
    }
}
