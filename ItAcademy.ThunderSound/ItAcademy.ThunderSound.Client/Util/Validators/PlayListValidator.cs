using FluentValidation;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Util.Validators
{
    public class PlayListValidator : AbstractValidator<PlayListViewModel>
    {
        public PlayListValidator()
        {
            RuleFor(x => x.PlayListName)
             .NotEmpty().WithMessage("PlayList Name is required")
             .MaximumLength(25).WithMessage("PlayList Name can have a max of 25 characters.");
        }
    }
}