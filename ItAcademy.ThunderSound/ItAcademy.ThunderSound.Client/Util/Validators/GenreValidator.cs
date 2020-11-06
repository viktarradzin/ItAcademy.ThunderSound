using FluentValidation;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Util.Validators
{
    public class GenreValidator : AbstractValidator<GenreViewModel>
    {
        public GenreValidator()
        {
            RuleFor(x => x.GenreName)
             .NotEmpty().WithMessage("Genre Name is required")
             .MaximumLength(25).WithMessage("Genre Name can have a max of 25 characters.");
        }
    }
}