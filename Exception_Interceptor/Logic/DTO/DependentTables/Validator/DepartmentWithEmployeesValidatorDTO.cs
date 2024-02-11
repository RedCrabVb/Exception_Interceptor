using FluentValidation;

namespace Exception_Interceptor.Logic.DTO.DependentTables.Validator
{
    public class DepartmentWithEmployeesValidatorDTO : AbstractValidator<DepartmentWithEmployeesDTO>
    {
        public DepartmentWithEmployeesValidatorDTO()
        {
            RuleFor(departmentWithEmployees => departmentWithEmployees.DepartmentDTO)
                .SetValidator(new DepartmentValidatorDTO());
        }
    }
}
