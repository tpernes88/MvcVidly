namespace VidlyMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieListToDb : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAddedDb, NumberInStock) VALUES ('Hangover', 5, 11/06/2009, 04/11/2019, 3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAddedDb, NumberInStock) VALUES ('Die Hard', 1, 12/07/1988, 04/11/2019, 5)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAddedDb, NumberInStock) VALUES ('The Terminator', 1, 24/05/1985, 04/11/2019, 2)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAddedDb, NumberInStock) VALUES ('Toy Story', 3, 29/03/1996, 04/11/2019, 6)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAddedDb, NumberInStock) VALUES ('Titanic', 4, 16/01/1998, 04/11/2019, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
