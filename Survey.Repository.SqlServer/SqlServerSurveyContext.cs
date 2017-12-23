using System;
using System.Data.Entity;
using System.Linq;
using Survey.Core.Models;

namespace Survey.Repository.SqlServer
{
    public class SqlServerSurveyContext : DbContext
    {
        public SqlServerSurveyContext()
            : base("name=SqlServerSurveyContext")
        {
        }

        public virtual DbSet<SurveyPlan> SurveyPlans { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<FinishedSurvey> FinishedSurveys { get; set; }
        public virtual DbSet<FinishedSurveyAnswer> FinishedSurveyAnswers { get; set; }
    }
}