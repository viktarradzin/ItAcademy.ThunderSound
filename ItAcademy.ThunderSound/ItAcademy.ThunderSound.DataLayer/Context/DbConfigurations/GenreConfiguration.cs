using ItAcademy.ThunderSound.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.ThunderSound.DataLayer.Context.DbConfigurations
{
    class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration() 
        {
            ToTable("Genres");

            HasKey(x => x.GenreId);

            Property(x => x.Name).IsRequired().HasMaxLength(25);

            Property(x => x.Image).IsOptional().IsMaxLength();

            HasMany<Singer>(x => x.Singers)
              .WithRequired(x => x.Genre)
              .Map(m => m.MapKey("GenreId"))
              .WillCascadeOnDelete(false);

            HasMany<PlayList>(x => x.PlayLists)
              .WithRequired(x => x.Genre)
              .Map(m => m.MapKey("GenreId"))
              .WillCascadeOnDelete(true);

            HasMany<Track>(x => x.Tracks)
              .WithRequired(s => s.Genre)
              .Map(m => m.MapKey("GenreId"))
              .WillCascadeOnDelete(true);
        }
    }
}
