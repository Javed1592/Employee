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


        [HttpGet("{id}")]
        public IEnumerable<Employee> EMPGet(int id)
        {
            EMPContext dataContext = new EMPContext();            
            var employees = dataContext.Employee.Where(x => x.employeeId == id);
            return employees;
        }

        [HttpPost]
        public IActionResult EMPPost(Employee emp)
        {
            using (EMPContext dataContext = new EMPContext())
            {
                dataContext.Employee.Add(emp);                
                dataContext.SaveChanges();
            }
            return CreatedAtAction("Get",emp);
         }

        [HttpPut]
        public IActionResult EMPPut(int id, Employee emp)
        {
            if(id != emp.employeeId)
            {
                return BadRequest();
            }
            
            using (EMPContext dataContext = new EMPContext())
            {
                dataContext.SaveChanges();

            }
            return CreatedAtAction("Get", emp);
        }
        [HttpDelete]
        public IActionResult EMPDelete(int id)
        {
            EMPContext datacontext = new EMPContext();
            var emp_val = datacontext.Employee.FindAsync(id);
            datacontext.Remove(emp_val);
            datacontext.SaveChanges();
            return Ok();
        }
    }
}