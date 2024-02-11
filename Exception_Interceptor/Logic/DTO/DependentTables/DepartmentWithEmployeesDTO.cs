using System.ComponentModel.DataAnnotations;

namespace Exception_Interceptor.Logic.DTO.DependentTables
{
    public class DepartmentWithEmployeesDTO
    {
        [Required]
        public DepartmentDTO DepartmentDTO { get; set; }
        [Required]
        public IEnumerable<EmployeeDTO> Employees { get; set; }
    }
}
