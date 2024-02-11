using FluentValidation;

namespace Exception_Interceptor.Logic.DTO.DependentTables.Validator
{
    public class DepartmentsWithEmployeesValidatorDTO : AbstractValidator<DepartmentsWithEmployeesDTO>
    {
        public DepartmentsWithEmployeesValidatorDTO()
        {
            RuleForEach(departmentWithEmployees => departmentWithEmployees.Value)
                .SetValidator(new DepartmentWithEmployeesValidatorDTO());
        }
    }
}
