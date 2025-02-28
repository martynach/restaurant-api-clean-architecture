using FluentValidation;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.Validators;

public class CreateRestaurantDtoValidator: AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];
    
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.Category)
            // .Must(c => validCategories.Contains(c)).WithMessage("Please provide valid category");
            .Must(validCategories.Contains).WithMessage("Please provide valid category");
            // .Custom((category, context) =>
            // {
            //     var isValid = validCategories.Select(c => c.ToLower()).Contains(category?.ToLower());
            //
            //     if (!isValid)
            //     {
            //         var validCategoriesMessage = "";
            //         foreach (var cat in validCategories)
            //         {
            //             if (!String.IsNullOrWhiteSpace(validCategoriesMessage))
            //             {
            //                 validCategoriesMessage += ", ";
            //             }
            //             validCategoriesMessage += cat;
            //         }
            //         
            //         context.AddFailure("Category",$"Category should be one of: {validCategoriesMessage}.");
            //     }
            //
            // });

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Insert valid email");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Provide valid postal code (xx-xxx)");
    }
    
}