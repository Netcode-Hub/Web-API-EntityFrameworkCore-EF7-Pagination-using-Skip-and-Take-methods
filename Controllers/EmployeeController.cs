using EFCoreRelationships.Data;
using EFCoreRelationships.DTOs;
using EFCoreRelationships.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<List<Employee>>> GetEmployees(int page)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling(appDbContext.Employees.Count() / pageResults);
            var employees = await appDbContext.Employees.Skip((page - 1) * (int)pageResults).Take((int)pageResults).ToListAsync();

            var response = new ResponseDTO
            {
                Employees = employees,
                CurrentPage = page,
                Page = (int)pageCount
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseDTO>>> GetAllEmployees()
        {
            var emps =  await appDbContext.Employees.ToListAsync();
            return Ok(emps);
        }
    }
}
