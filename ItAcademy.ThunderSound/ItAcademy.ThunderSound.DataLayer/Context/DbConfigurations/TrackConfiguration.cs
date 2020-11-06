using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DataLayer.Context.DbConfigurations
{
    public class TrackConfiguration : EntityTypeConfiguration<TrackModel>
    {
        public TrackConfiguration()
        {
            ToTable("Tracks");

            HasKey(x => x.TrackId);

            Property(x => x.TrackId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.TrackName)
                .IsRequired()
                .HasMaxLength(25);

            Property(x => x.File)
                .IsRequired()
                .IsMaxLength();
        }
    }
}