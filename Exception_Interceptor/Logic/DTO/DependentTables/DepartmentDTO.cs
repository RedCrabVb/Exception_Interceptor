using SqlKata;
using System.ComponentModel.DataAnnotations;

namespace Exception_Interceptor.Logic.DTO.DependentTables
{
    public class DepartmentDTO 
    {
        [Required]
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("manager_name")]
        public string ManagerName { get; set; }
    }
}
