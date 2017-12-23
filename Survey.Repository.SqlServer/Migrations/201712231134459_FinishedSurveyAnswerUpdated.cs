namespace Survey.Repository.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishedSurveyAnswerUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinishedSurveyAnswers", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.FinishedSurveyAnswers", "QuestionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FinishedSurveyAnswers", new[] { "QuestionId" });
            DropColumn("dbo.FinishedSurveyAnswers", "QuestionId");
        }
    }
}
