using System.ComponentModel.DataAnnotations;

namespace ResourceAllocationProject.Models
{
    public class AliMonitor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
