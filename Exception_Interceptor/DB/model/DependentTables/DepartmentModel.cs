using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exception_Interceptor.DB.model.DependentTables
{
    public class DepartmentModel
    {
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("manager_name")]
        public string ManagerName { get; set; }
    }
}
