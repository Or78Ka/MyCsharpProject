namespace TinyShelterPage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Age = c.Double(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Animals");
        }
    }
}
