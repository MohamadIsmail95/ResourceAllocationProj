using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using ResourceAllocationProject.Models;
using ResourceAllocationProject.Services.EmployeeService.ViewModel;
using System.Linq;
using static ResourceAllocationProject.Services.EmployeeService.ViewModel.EmployeeViewModels;

namespace ResourceAllocationProject.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _db;

        private List<AliMonitor> excludeMonitor = new List<AliMonitor>();
        public EmployeeService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<EmployeeAllocation>> EmployeeDistribution()
        {

            List<EmployeeAllocation> result = new List<EmployeeAllocation>();
            var availableMonitors = await _db.AliMonitors.ToListAsync();
            var employees = await _db.AliMointorPlans.OrderBy(x => x.City).ToListAsync();
            foreach (var employee in employees)
            {
                EmployeeAllocation allocation = new EmployeeAllocation(SelectMonitor(employee, availableMonitors), employee.AvayaName, employee.City);
                result.Add(allocation);
            }


            return result.OrderBy(x=> x.MonitorName).ToList();

        }
        public async Task<string> ConvertJsonToXlsx(List<EmployeeAllocation> input)
        {
            try
            {

                // populate excel spreadsheet
                var fileName = "EmployeeAllocation.xlsx";
                string savePath = $@"./AllocationFolders/"+ fileName;

                var fileInfo = new FileInfo(savePath);

                using (var excelFile = new ExcelPackage(fileInfo))
                {
                    // add worksheet if not exists
                    if (!excelFile.Workbook.Worksheets.Any(ar => ar.Name == "Monitors"))
                        excelFile.Workbook.Worksheets.Add("Monitors");

                    var ws = excelFile.Workbook.Worksheets["Monitors"];

                    // headers
                    ws.Cells[1, 1].Value = "MonitorName";
                    ws.Cells[1, 2].Value = "EmployeeName";
                    ws.Cells[1, 3].Value = "CityName";


                    // content
                    int row = 2;
                    foreach (var o in input)
                    {
                        ws.Cells[row, 1].Value = o.MonitorName;
                        ws.Cells[row, 2].Value = o.EmployeeName;
                        ws.Cells[row, 3].Value = o.CityName;

                        row++;
                    }

                    excelFile.Save();
                }

                return savePath;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string SelectMonitor(AliMointorPlan emp , List<AliMonitor> monitors )
        {
            Random rnd = new Random();

            if (excludeMonitor.Count()== monitors.Count())
            {
                excludeMonitor = new List<AliMonitor>();
                SelectMonitor(emp, monitors);

            }
        
            var selectedMonitor = monitors.Except(excludeMonitor).Where(x => x.Name != emp.NewUser && x.Name != emp.M1 && x.Name != emp.M2).ToList();
            int selectedRnd = rnd.Next(0, selectedMonitor.Count() - 1);
            excludeMonitor.Add(selectedMonitor[selectedRnd]);
            return selectedMonitor[selectedRnd].Name;


        }
    }
}
