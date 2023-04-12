using FluentValidation;
using SAM.Application.DTOS.Request;

namespace SAM.Application.Validators.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDTO>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotNull().WithMessage("The field Name can not be null")
                .NotEmpty().WithMessage("The field Name can not be empty");
        }
    }
}
