namespace ResourceAllocationProject.Services.EmployeeService.ViewModel
{
    public class EmployeeViewModels
    {
        public class EmployeesViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public long EmpId { get; set; }
            public string? M1Name { get; set; }
            public string? M2Name { get; set; }
            public string? M3Name { get; set; }

        }

        public class EmployeeAllocation
        {
            public string MonitorName { get; set; }
            public string EmployeeName { get; set; }
            public string CityName { get; set; }


            public EmployeeAllocation(string monitorName , string employeeName , string cityName)
            {
                MonitorName= monitorName;
                EmployeeName= employeeName;
                CityName= cityName;
            }

        }
    }
}
