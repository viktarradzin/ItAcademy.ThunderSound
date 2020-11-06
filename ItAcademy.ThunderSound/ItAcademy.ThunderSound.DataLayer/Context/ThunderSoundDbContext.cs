using System.Data.Entity;
using ItAcademy.ThunderSound.DomainLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ItAcademy.ThunderSound.DataLayer.Context
{
    public class ThunderSoundDbContext : IdentityDbContext, IThunderSoundDbContext
    {
        public ThunderSoundDbContext()
            : base("name=ThunderSound")
        {
            Database.SetInitializer(new NullDatabaseInitializer<ThunderSoundDbContext>());
        }

        public ThunderSoundDbContext(string conectionString)
            : base(conectionString)
        {
            Database.SetInitializer(new NullDatabaseInitializer<ThunderSoundDbContext>());
        }

        public DbSet<TrackModel> Tracks { get; set; }

        public DbSet<SingerModel> Singers { get; set; }

        public DbSet<PlayListModel> PlayLists { get; set; }

        public DbSet<GenreModel> Genre { get; set; }

        public DbSet<LabelModel> Label { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}