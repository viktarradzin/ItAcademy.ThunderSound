namespace ItAcademy.ThunderSound.DataLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                {
                    GenreId = c.Int(nullable: false, identity: true),
                    GenreName = c.String(nullable: false, maxLength: 25),
                    Image = c.Binary(),
                })
                .PrimaryKey(t => t.GenreId);

            CreateTable(
                "dbo.PlayLists",
                c => new
                {
                    PlayListId = c.Int(nullable: false, identity: true),
                    PlayListName = c.String(nullable: false, maxLength: 25),
                    Image = c.Binary(),
                    LabelId = c.Int(nullable: false),
                    SingerId = c.Int(nullable: false),
                    GenreId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PlayListId)
                .ForeignKey("dbo.Labels", t => t.LabelId, cascadeDelete: true)
                .ForeignKey("dbo.Singers", t => t.SingerId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.LabelId)
                .Index(t => t.SingerId)
                .Index(t => t.GenreId);

            CreateTable(
                "dbo.Labels",
                c => new
                {
                    LabelId = c.Int(nullable: false, identity: true),
                    LabelName = c.String(nullable: false, maxLength: 25),
                    Image = c.Binary(),
                })
                .PrimaryKey(t => t.LabelId);

            CreateTable(
                "dbo.Singers",
                c => new
                {
                    SingerId = c.Int(nullable: false, identity: true),
                    SingerName = c.String(nullable: false, maxLength: 25),
                    Image = c.Binary(),
                })
                .PrimaryKey(t => t.SingerId);

            CreateTable(
                "dbo.Tracks",
                c => new
                {
                    TrackId = c.Int(nullable: false, identity: true),
                    TrackName = c.String(nullable: false, maxLength: 25),
                    File = c.Binary(nullable: false),
                    SingerId = c.Int(nullable: false),
                    PlayListId = c.Int(nullable: false),
                    GenreId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.Singers", t => t.SingerId, cascadeDelete: true)
                .ForeignKey("dbo.PlayLists", t => t.PlayListId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.SingerId)
                .Index(t => t.PlayListId)
                .Index(t => t.GenreId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.PlayLists", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Tracks", "PlayListId", "dbo.PlayLists");
            DropForeignKey("dbo.Tracks", "SingerId", "dbo.Singers");
            DropForeignKey("dbo.PlayLists", "SingerId", "dbo.Singers");
            DropForeignKey("dbo.PlayLists", "LabelId", "dbo.Labels");
            DropIndex("dbo.Tracks", new[] { "GenreId" });
            DropIndex("dbo.Tracks", new[] { "PlayListId" });
            DropIndex("dbo.Tracks", new[] { "SingerId" });
            DropIndex("dbo.PlayLists", new[] { "GenreId" });
            DropIndex("dbo.PlayLists", new[] { "SingerId" });
            DropIndex("dbo.PlayLists", new[] { "LabelId" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Singers");
            DropTable("dbo.Labels");
            DropTable("dbo.PlayLists");
            DropTable("dbo.Genres");
        }
    }
}
