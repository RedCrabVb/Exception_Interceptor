using Dapper;
using Exception_Interceptor.Logic.DTO.DependentTables;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Exception_Interceptor.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class DependentTablesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DependentTablesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("Save")]
        //AI Gen
        public IActionResult SaveDepartmentsAndEmployeesAIGen([FromBody] DepartmentsWithEmployeesDTO departmentsWithEmployees)
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                foreach (var departmentEntry in departmentsWithEmployees.Value)
                {
                    var department = departmentEntry.DepartmentDTO;
                    var employees = departmentEntry.Employees;

                    // Проверяем, существует ли отдел
                    var existingDepartment = connection.QueryFirstOrDefault<DepartmentDTO>(
                        "SELECT * FROM departments WHERE Department_Id = @DepartmentId",
                        new { department.DepartmentId },
                        transaction: transaction
                    );

                    // Обновляем отдел, если он существует, или вставляем новый
                    if (existingDepartment != null)
                    {
                        // Обновляем отдел
                        connection.Execute(
                            "UPDATE departments SET manager_name = @ManagerName WHERE department_id = @DepartmentId",
                            new { department.ManagerName, existingDepartment.DepartmentId },
                            transaction: transaction
                        );
                        department.DepartmentId = existingDepartment.DepartmentId;
                    }
                    else
                    {
                        // Вставляем новый отдел
                        department.DepartmentId = connection.QuerySingle<int>(
                            "INSERT INTO departments (name, manager_name) VALUES (@Name, @ManagerName) returning Department_Id",
                            department,
                            transaction: transaction
                        );
                    }

                    // Вставляем сотрудников этого отдела
                    foreach (var employee in employees)
                    {
                        connection.Execute(
                            "INSERT INTO employees (first_name, last_name, department_id) VALUES (@FirstName, @LastName, @DepartmentId)",
                            new { employee.FirstName, employee.LastName, department.DepartmentId },
                            transaction: transaction
                        );
                    }
                }

                transaction.Commit();

                return Ok("Ok");
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }


        [HttpPost("Save")]
        //AI Gen
        public IActionResult SaveDepartmentsAndEmployees([FromBody] DepartmentsWithEmployeesDTO departmentsWithEmployees)
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                foreach (var departmentEntry in departmentsWithEmployees.Value)
                {
                    var department = departmentEntry.DepartmentDTO;
                    var employees = departmentEntry.Employees;

                    // Проверяем, существует ли отдел
                    var existingDepartment = connection.QueryFirstOrDefault<DepartmentDTO>(
                        "SELECT * FROM departments WHERE Department_Id = @DepartmentId",
                        new { department.DepartmentId },
                        transaction: transaction
                    );

                    // Обновляем отдел, если он существует, или вставляем новый
                    if (existingDepartment != null)
                    {
                        // Обновляем отдел
                        connection.Execute(
                            "UPDATE departments SET manager_name = @ManagerName WHERE department_id = @DepartmentId",
                            new { department.ManagerName, existingDepartment.DepartmentId },
                            transaction: transaction
                        );
                        department.DepartmentId = existingDepartment.DepartmentId;
                    }
                    else
                    {
                        // Вставляем новый отдел
                        department.DepartmentId = connection.QuerySingle<int>(
                            "INSERT INTO departments (name, manager_name) VALUES (@Name, @ManagerName) returning Department_Id",
                            department,
                            transaction: transaction
                        );
                    }

                    // Вставляем сотрудников этого отдела
                    foreach (var employee in employees)
                    {
                        connection.Execute(
                            "INSERT INTO employees (first_name, last_name, department_id) VALUES (@FirstName, @LastName, @DepartmentId)",
                            new { employee.FirstName, employee.LastName, department.DepartmentId },
                            transaction: transaction
                        );
                    }
                }

                transaction.Commit();

                return Ok("Ok");
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
