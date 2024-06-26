using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ResourceAllocationProject.Services.EmployeeService;
using System.IO;

namespace ResourceAllocationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }



        [HttpGet("ExportAllocationData")]

        public async Task<IActionResult> ExportAllocationData()
        {
            var data = await _employeeService.EmployeeDistribution();
            var convertedData = await _employeeService.ConvertJsonToXlsx(data);
            var f = new FileStream(convertedData, FileMode.Open, FileAccess.Read);
            return File(f, "application/octet-stream", "EmployeeAllocation.xlsx");
        }


    }
}
