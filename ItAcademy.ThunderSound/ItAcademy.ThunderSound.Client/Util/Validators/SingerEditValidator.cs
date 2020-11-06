using FluentValidation;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Util.Validators
{ 
    public class SingerEditValidator : AbstractValidator<SingerViewModelEdit>
    {
         public SingerEditValidator()
          {
                RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Track name is required")
                .MaximumLength(25).WithMessage("First Name can have a max of 25 characters.");
                RuleFor(x => x.Genre.GenreId)
                .NotEmpty().WithMessage("Genre is required.");

          }
    }
}
