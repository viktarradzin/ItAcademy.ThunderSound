namespace ItAcademy.ThunderSound.DataLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedLinkBetweenGenresAndSingers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Singers", "GenreId", c => c.Int());
            CreateIndex("dbo.Singers", "GenreId");
            AddForeignKey("dbo.Singers", "GenreId", "dbo.Genres", "GenreId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Singers", "GenreId", "dbo.Genres");
            DropIndex("dbo.Singers", new[] { "GenreId" });
            DropColumn("dbo.Singers", "GenreId");
        }
    }
}
