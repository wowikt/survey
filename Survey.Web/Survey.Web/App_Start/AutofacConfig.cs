using Autofac;
using Autofac.Integration.Mvc;
using Survey.App.AppServices;
using Survey.App.Interfaces;
using Survey.Core.Repositories;
using Survey.Repository.SqlServer.Configurations;
using Survey.Repository.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey.Web
{
    /// <summary>
    /// Настройка конфигурации autofac
    /// </summary>
    public static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            string dbProviderName = ConfigurationManager.AppSettings["DbProvider"].ToLower();
            if (dbProviderName == "sqlserver")
            {
                SqlServerAutofacConfig.Configure(builder);
            }

            builder.RegisterType<SurveyPlanService>().As<ISurveyPlanService>();
            builder.RegisterType<FinishedSurveyService>().As<IFinishedSurveyService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}