using Autofac;
using Survey.Core.Repositories;
using Survey.Repository.SqlServer.Repositories;

namespace Survey.Repository.SqlServer.Configurations
{
    public class SqlServerAutofacConfig
    {
        /// <summary>
        /// Регистрация типов репозиториев в autofac
        /// </summary>
        /// <param name="builder"></param>
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<SurveyPlanRepository>().As<ISurveyPlanRepository>();
            builder.RegisterType<FinishedSurveyRepository>().As<IFinishedSurveyRepository>();
        }
    }
}
