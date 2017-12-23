namespace Survey.Repository.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContextFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FinishedSurveyAnswers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.FinishedSurveyAnswers", new[] { "QuestionId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.FinishedSurveyAnswers", "QuestionId");
            AddForeignKey("dbo.FinishedSurveyAnswers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}
