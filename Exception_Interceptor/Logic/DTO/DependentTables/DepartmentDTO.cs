using System.ComponentModel.DataAnnotations;

namespace Exception_Interceptor.Logic.DTO.DependentTables
{
    public class DepartmentDTO 
    {
        [Required]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
    }
}
