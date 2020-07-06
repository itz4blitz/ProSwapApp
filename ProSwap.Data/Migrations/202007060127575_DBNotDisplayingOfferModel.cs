namespace ProSwap.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBNotDisplayingOfferModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Game", "CurrencyPriceUSD");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "CurrencyPriceUSD", c => c.Double(nullable: false));
        }
    }
}
