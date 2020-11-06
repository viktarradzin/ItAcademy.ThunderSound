using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DataLayer.Context.DbConfigurations
{
    public class PlayListConfiguration : EntityTypeConfiguration<PlayListModel>
    {
        public PlayListConfiguration()
        {
            ToTable("PlayLists");

            HasKey(x => x.PlayListId);

            Property(x => x.PlayListId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.PlayListName)
                .IsRequired()
                .HasMaxLength(25);

            Property(x => x.Image)
                .IsOptional()
                .IsMaxLength();

            HasMany(x => x.Tracks)
               .WithRequired(x => x.PlayList)
               .Map(m => m.MapKey("PlayListId"))
               .WillCascadeOnDelete(false);
        }
    }
}