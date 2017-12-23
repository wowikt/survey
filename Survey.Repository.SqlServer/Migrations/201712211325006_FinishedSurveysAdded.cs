namespace Survey.Repository.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishedSurveysAdded : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Questions", name: "SurveyId", newName: "SurveyPlanId");
            RenameIndex(table: "dbo.Questions", name: "IX_SurveyId", newName: "IX_SurveyPlanId");
            CreateTable(
                "dbo.FinishedSurveyAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FinishedSurveyId = c.Int(nullable: false),
                        AnswerId = c.Int(),
                        AnswerText = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId)
                .ForeignKey("dbo.FinishedSurveys", t => t.FinishedSurveyId, cascadeDelete: true)
                .Index(t => t.FinishedSurveyId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.FinishedSurveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyPlanId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyPlans", t => t.SurveyPlanId, cascadeDelete: true)
                .Index(t => t.SurveyPlanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinishedSurveys", "SurveyPlanId", "dbo.SurveyPlans");
            DropForeignKey("dbo.FinishedSurveyAnswers", "FinishedSurveyId", "dbo.FinishedSurveys");
            DropForeignKey("dbo.FinishedSurveyAnswers", "AnswerId", "dbo.Answers");
            DropIndex("dbo.FinishedSurveys", new[] { "SurveyPlanId" });
            DropIndex("dbo.FinishedSurveyAnswers", new[] { "AnswerId" });
            DropIndex("dbo.FinishedSurveyAnswers", new[] { "FinishedSurveyId" });
            DropTable("dbo.FinishedSurveys");
            DropTable("dbo.FinishedSurveyAnswers");
            RenameIndex(table: "dbo.Questions", name: "IX_SurveyPlanId", newName: "IX_SurveyId");
            RenameColumn(table: "dbo.Questions", name: "SurveyPlanId", newName: "SurveyId");
        }
    }
}
