using FastEndpoints;
using FluentValidation;
using SmartCafe.Menu.Api.Models.Category;

namespace SmartCafe.Menu.Api.Validation.Category;

public sealed class CreateCategoryRequestValidator : Validator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Priority)
            .GreaterThan(0)
            .WithMessage("The priority of the category must be greater than 0");
    }
}
