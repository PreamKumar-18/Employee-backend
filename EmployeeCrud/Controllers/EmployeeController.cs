using EmployeeCrud.Data;
using EmployeeCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public ActionResult <IEnumerable<EmployeeController>> GetAll() 
        {
            var employees = _dbContext.Employees.ToList();

            return Ok(employees);
        }

        [HttpGet("{id:int}")]

        public ActionResult<Employee> GetById(int id)
        {
            var employee = _dbContext.Employees.Find(id);

            return Ok(employee);


        }

        [HttpPost]

        public ActionResult<Employee> Create([FromBody]  Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id:int}")]

        public ActionResult<Employee> Update(int id,[FromBody] Employee employee)
        {
            var employeeFromDb = _dbContext.Employees.Find(id);

            employeeFromDb.FirstName = employee.FirstName;
            employeeFromDb.LastName = employee.LastName;
            employeeFromDb.Email = employee.Email;

            _dbContext.Employees.Update(employeeFromDb);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id:int}")]

        public ActionResult<Employee> GetByid(int id)
        {
            var employee = _dbContext.Employees.Find(id);

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
