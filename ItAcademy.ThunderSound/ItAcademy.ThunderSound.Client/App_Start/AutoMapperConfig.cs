using AutoMapper;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.Client.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TrackModel, TrackViewModel>()
                .ForMember(
                    dest => dest.Singer,
                    opt => opt.MapFrom(scr => scr.Singer))
                .ForMember(
                    dest => dest.PlayList,
                    opt => opt.MapFrom(scr => scr.PlayList))
                .ForMember(
                    dest => dest.Genre,
                    opt => opt.MapFrom(scr => scr.Genre))
                .ReverseMap();

            cfg.CreateMap<GenreModel, GenreViewModel>()
                .ForMember(
                    dest => dest.GenreId,
                    opt => opt.MapFrom(scr => scr.GenreId))
                .ForMember(
                    dest => dest.GenreName,
                    opt => opt.MapFrom(scr => scr.GenreName))
                .ReverseMap();

            cfg.CreateMap<SingerModel, SingerViewModel>()
                .ForMember(
                    dest => dest.SingerId,
                    opt => opt.MapFrom(scr => scr.SingerId))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(scr => scr.SingerName))
                .ForMember(
                    dest => dest.Image,
                    opt => opt.MapFrom(scr => scr.Image))
                .ReverseMap();

            cfg.CreateMap<LabelModel, LabelViewModel>()
                .ForMember(
                    dest => dest.LabelId,
                    opt => opt.MapFrom(scr => scr.LabelId))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(scr => scr.LabelName))
                .ForMember(
                    dest => dest.Image,
                    opt => opt.MapFrom(scr => scr.Image))
                .ReverseMap();

            cfg.CreateMap<PlayListModel, PlayListViewModel>()
                .ForMember(
                    dest => dest.PlayListId,
                    opt => opt.MapFrom(scr => scr.PlayListId))
                .ForMember(
                    dest => dest.PlayListName,
                    opt => opt.MapFrom(scr => scr.PlayListName))
                .ForMember(
                    dest => dest.Image,
                    opt => opt.MapFrom(scr => scr.Image))
                .ForMember(
                    dest => dest.Singer,
                    opt => opt.MapFrom(scr => scr.Singer))
                .ForMember(
                    dest => dest.Genre,
                    opt => opt.MapFrom(scr => scr.Genre))
                .ForMember(
                    dest => dest.Tracks,
                    opt => opt.MapFrom(scr => scr.Tracks))
                .ForMember(
                    dest => dest.Label,
                    opt => opt.MapFrom(scr => scr.Label))
                .ReverseMap();
        }
    }
}