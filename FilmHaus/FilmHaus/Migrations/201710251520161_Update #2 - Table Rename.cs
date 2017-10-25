namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2TableRename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Person", newName: "People");
            RenameTable(name: "dbo.List", newName: "Lists");
            RenameTable(name: "dbo.Review", newName: "Reviews");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Reviews", newName: "Review");
            RenameTable(name: "dbo.Lists", newName: "List");
            RenameTable(name: "dbo.People", newName: "Person");
        }
    }
}
