namespace VidlyMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDatesType : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies ALTER COLUMN ReleaseDate DATETIME2");
            Sql("ALTER TABLE Movies ALTER COLUMN DateAddedDb DATETIME2");
        }
        
        public override void Down()
        {
        }
    }
}
