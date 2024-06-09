using JobPortal.Database;
using JobPortal.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext EmployeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext) 
        {
            this.EmployeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            try 
            {
                var employee = await EmployeeDbContext.Employees.ToListAsync();
                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee emp) 
        {
            var employee = await EmployeeDbContext.Employees.ToListAsync();
            emp.Id = new Guid();
            await EmployeeDbContext.Employees.AddAsync(emp);
            await EmployeeDbContext.SaveChangesAsync();
            return Ok(emp);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] Employee emp)
        {
            var employeeEdit = await EmployeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employeeEdit != null) 
            {
                employeeEdit.Name = emp.Name;
                employeeEdit.Email = emp.Email;
                employeeEdit.JobRole = emp.JobRole;
                employeeEdit.WorkExperience = emp.WorkExperience;
                employeeEdit.CurrentCTC = emp.CurrentCTC;
                employeeEdit.ExpectedCTC = emp.ExpectedCTC;
                employeeEdit.NoticePeriod = emp.NoticePeriod;

                await EmployeeDbContext.SaveChangesAsync();
                return Ok(emp);
            }
            else
            {
                return NotFound("Employee Not Found");
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public  async  Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employeeDelete = await EmployeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employeeDelete != null)
            {
                EmployeeDbContext.Employees.Remove(employeeDelete);
                await EmployeeDbContext.SaveChangesAsync();
                return Ok(employeeDelete);
            }
            else { return NotFound("Employee Not Found"); }

        }
    }
}
