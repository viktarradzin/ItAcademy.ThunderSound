using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DataLayer.Context.DbConfigurations
{
    public class LabelConfiguration : EntityTypeConfiguration<LabelModel>
    {
        public LabelConfiguration()
        {
            ToTable("Labels");

            HasKey(x => x.LabelId);

            Property(x => x.LabelId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.LabelName)
                .IsRequired()
                .HasMaxLength(25);

            Property(x => x.Image)
                .IsOptional()
                .IsMaxLength();

            HasMany(x => x.PlayLists)
              .WithRequired(x => x.Label)
              .Map(m => m.MapKey("LabelId"))
              .WillCascadeOnDelete(true);
        }
    }
}