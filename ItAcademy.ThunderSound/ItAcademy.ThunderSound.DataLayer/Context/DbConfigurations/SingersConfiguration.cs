using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DataLayer.Context.DbConfigurations
{
    public class SingersConfiguration : EntityTypeConfiguration<SingerModel>
    {
        public SingersConfiguration()
        {
            ToTable("Singers");

            HasKey(x => x.SingerId);

            Property(x => x.SingerId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.SingerName)
                .IsRequired()
                .HasMaxLength(25);

            Property(x => x.Image)
                .IsOptional()
                .IsMaxLength();

            HasMany(x => x.PlayLists)
                .WithRequired(x => x.Singer)
                .Map(m => m.MapKey("SingerId"))
                .WillCascadeOnDelete(true);

            HasMany(x => x.Tracks)
                .WithRequired(x => x.Singer)
                .Map(m => m.MapKey("SingerId"))
                .WillCascadeOnDelete(true);
        }
    }
}