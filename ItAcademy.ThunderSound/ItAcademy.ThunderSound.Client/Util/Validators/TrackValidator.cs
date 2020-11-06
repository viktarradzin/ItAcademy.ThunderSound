using FluentValidation;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;

namespace ItAcademy.ThunderSound.Client.Util.Validators
{
    public class TrackValidator : AbstractValidator<TrackViewModel>
    {
        private readonly ITrackPresentationService trackPresentationService;

        private readonly IGenrePresentationService genrePresentationService;

        private readonly ISingerPresentationService singerPresentationService;

        private readonly IPlayListPresentationService playListPresentationService;

        public TrackValidator()
        {
        }

        public TrackValidator(
            IGenrePresentationService genrePresentationService,
            ITrackPresentationService trackPresentationService,
            ISingerPresentationService singerPresentationService,
            IPlayListPresentationService playListPresentationService)
        {
            this.genrePresentationService = genrePresentationService;

            this.trackPresentationService = trackPresentationService;

            this.singerPresentationService = singerPresentationService;

            this.playListPresentationService = playListPresentationService;

            RuleFor(x => x.TrackName)
                .NotEmpty()
                .WithMessage("Track name is required")
                .MaximumLength(25)
                .WithMessage("First Name can have a max of 25 characters.");

            // RuleFor(x => x.UploadTrack)
            //    .NotEmpty()
            //    .WithMessage("File is required.");
            RuleFor(x => x.Genre.GenreId)
                .NotEmpty()
                .WithMessage("Genre is required.")
                .Must(GenreExists)
                .WithMessage("The genre must be present");

            RuleFor(x => x.Singer.SingerId)
                .NotEmpty()
                .WithMessage("Singer is required.");

            RuleFor(x => x.PlayList.PlayListId)
                .NotEmpty()
                .WithMessage("PlayList is required.");

            RuleFor(x => x)
                .Must(BelongSingerToTheGenre)
                .WithMessage("The singer must belong to a specific album");

            RuleFor(x => x)
                .Must(BelongPlayListToTheSinger)
                .WithMessage("The playlist must belong to a specific singer");
        }

        private bool BelongPlayListToTheSinger(TrackViewModel track)
        {
            return playListPresentationService.BelongPlayListsToTheSinger(track);
        }

        private bool BelongSingerToTheGenre(TrackViewModel track)
        {
            return singerPresentationService.BelongSingerToTheGenre(track);
        }

        private bool GenreExists(int genreId)
        {
            return genrePresentationService.IsGenreExists(genreId);
        }
    }
}