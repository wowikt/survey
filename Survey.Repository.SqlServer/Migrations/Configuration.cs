namespace Survey.Repository.SqlServer.Migrations
{
    using Survey.Core.DataItems;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Survey.Repository.SqlServer.SqlServerSurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Survey.Repository.SqlServer.SqlServerSurveyContext context)
        {
            //context.SurveyPlans.AddOrUpdate(sp => sp.Name, InitialDataSet.GetInitialData().ToArray());

            foreach (var surveyPlan in InitialDataSet.GetInitialData())
            {
                var questions = surveyPlan.Questions;

                surveyPlan.Questions = null;
                context.SurveyPlans.AddOrUpdate(sp => sp.Name, surveyPlan);
                context.SaveChanges();

                var insertedSurveyPlan = context.SurveyPlans.Single(sp => sp.Name == surveyPlan.Name);
                foreach (var question in questions)
                {
                    question.SurveyPlanId = insertedSurveyPlan.Id;
                    context.Questions.AddOrUpdate(q => new { q.Text, q.SurveyPlanId }, question);
                    context.SaveChanges();

                    var insertedQuestion = context.Questions.Single(q => q.Text == question.Text);
                    if (question.Answers != null)
                    {
                        foreach (var answer in question.Answers)
                        {
                            answer.QuestionId = insertedQuestion.Id;
                            context.Answers.AddOrUpdate(a => new { a.Text, a.QuestionId }, answer);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
