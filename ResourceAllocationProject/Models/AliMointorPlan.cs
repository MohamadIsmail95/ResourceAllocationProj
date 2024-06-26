using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceAllocationProject.Models
{
    public class AliMointorPlan
    {
        [Key]
        public  int Id { get; set; }
        public string AvayaName { get; set; }
        public string City { get; set; }
        public string? M1 { get; set; }
        public string? M2 { get; set; }
        public string? M3 { get; set; }
        public string? NewUser { get; set; }
        public string? PlanId { get; set; }
    }
}
