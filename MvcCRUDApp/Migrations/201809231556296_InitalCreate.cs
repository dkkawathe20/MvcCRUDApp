namespace MvcCRUDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 15, fixedLength: true, unicode: false),
                        BirthDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MstAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(nullable: false, maxLength: 300),
                        AddressLine2 = c.String(maxLength: 300),
                        PinCode = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        AddressType = c.Int(),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        EmployeeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MstAddresses", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.MstAddresses", new[] { "EmployeeId" });
            DropTable("dbo.MstAddresses");
            DropTable("dbo.Employees");
        }
    }
}
