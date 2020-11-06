using System.Data.Entity.Migrations;

namespace ItAcademy.ThunderSound.DataLayer.Migrations
{
    public partial class IdentityRolesAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
    }
}
