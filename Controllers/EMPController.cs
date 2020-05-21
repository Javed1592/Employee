using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EMPController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            using (EMPContext dataContext = new EMPContext())
            {
                var employees = dataContext.Employee.ToList();
                return employees;
            }
        }

    }
}