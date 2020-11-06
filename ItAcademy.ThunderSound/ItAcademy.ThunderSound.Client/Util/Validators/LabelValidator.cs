using FluentValidation;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Util.Validators
{
    public class LabelValidator : AbstractValidator<LabelViewModel>
    {
        public LabelValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Label Name is required")
             .MaximumLength(25).WithMessage("Label Name can have a max of 25 characters.");
        }
    }
}