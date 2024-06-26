using static ResourceAllocationProject.Services.EmployeeService.ViewModel.EmployeeViewModels;

namespace ResourceAllocationProject.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<EmployeeAllocation>> EmployeeDistribution();

        Task<string> ConvertJsonToXlsx(List<EmployeeAllocation> input);
    }
}
