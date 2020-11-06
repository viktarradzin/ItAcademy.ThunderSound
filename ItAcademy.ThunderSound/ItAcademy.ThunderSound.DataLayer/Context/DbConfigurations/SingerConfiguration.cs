using ItAcademy.ThunderSound.DomainLayer.Models;
using System.Data.Entity.ModelConfiguration;


namespace ItAcademy.ThunderSound.DataLayer.Context.DbConfigurations
{
    class SingerConfiguration : EntityTypeConfiguration<Singer>
    {
        public SingerConfiguration() 
        {
            ToTable("Singers");

            HasKey(x => x.SingerId);

            Property(x => x.Name).IsRequired().HasMaxLength(25);

            Property(x => x.Image).IsOptional().IsMaxLength();

            HasMany<PlayList>(x => x.PlayLists)
                .WithRequired(x => x.Singer)
                .Map(m => m.MapKey("SingerId"))
                .WillCascadeOnDelete(true);

            HasMany<Track>(x => x.Tracks)
                .WithRequired(x => x.Singer)
                .Map(m => m.MapKey("SingerId"))
                .WillCascadeOnDelete(true);
        }

    }
}
