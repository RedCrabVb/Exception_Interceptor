
using FluentValidation;

namespace Exception_Interceptor.Logic.DTO.DependentTables.Validator
{
    public class DepartmentValidatorDTO : AbstractValidator<DepartmentDTO>
    {
        public DepartmentValidatorDTO()
        {
            RuleFor(x => x.DepartmentId).NotEqual(0);
            RuleFor(x => x.Name).NotEqual("string").NotNull().NotEmpty();
        }
    }
}
