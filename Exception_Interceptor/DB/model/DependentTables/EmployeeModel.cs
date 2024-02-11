using SqlKata;

namespace Exception_Interceptor.DB.model.DependentTables
{
    public class EmployeeModel
    {
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("department_id")]
        public int DepartmentId { get; set; }
    }
}
