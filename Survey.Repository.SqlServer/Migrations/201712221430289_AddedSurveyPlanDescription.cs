namespace Survey.Repository.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSurveyPlanDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyPlans", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyPlans", "Description");
        }
    }
}
