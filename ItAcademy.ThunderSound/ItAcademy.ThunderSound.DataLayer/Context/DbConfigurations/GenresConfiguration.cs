using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DataLayer.Context.DbConfigurations
{
    public class GenresConfiguration : EntityTypeConfiguration<GenreModel>
    {
        public GenresConfiguration()
        {
            ToTable("Genres");

            HasKey(x => x.GenreId);

            Property(x => x.GenreId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.GenreName)
                .IsRequired()
                .HasMaxLength(25);

            Property(x => x.Image)
                .IsOptional()
                .IsMaxLength();

            HasMany<PlayListModel>(x => x.PlayLists)
              .WithRequired(x => x.Genre)
              .Map(m => m.MapKey("GenreId"))
              .WillCascadeOnDelete(true);

            HasMany<TrackModel>(x => x.Tracks)
              .WithRequired(s => s.Genre)
              .Map(m => m.MapKey("GenreId"))
              .WillCascadeOnDelete(true);

            HasMany<SingerModel>(x => x.Singers)
              .WithOptional(s => s.Genre)
              .Map(m => m.MapKey("GenreId"))
              .WillCascadeOnDelete(false);
        }
    }
}