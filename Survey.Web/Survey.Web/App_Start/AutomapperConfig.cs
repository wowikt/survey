using AutoMapper;
using Survey.App.Models;
using Survey.Core.Models;
using Survey.Web.Models;

namespace Survey.Web
{
    /// <summary>
    /// Настройка конфигурации automapper
    /// </summary>
    public static class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SurveyPlan, SurveyPlanModel>();
                config.CreateMap<Question, QuestionModel>();
                config.CreateMap<Answer, AnswerModel>();
                config.CreateMap<FinishedSurvey, FinishedSurveyModel>();
                config.CreateMap<FinishedSurveyAnswer, FinishedSurveyAnswerModel>();

                config.CreateMap<SurveyPlanModel, SurveyPlanViewModel>();
                config.CreateMap<QuestionModel, QuestionViewModel>();
                config.CreateMap<AnswerModel, AnswerViewModel>();

                config.CreateMap<FinishedSurveyModel, FinishedSurvey>();
                config.CreateMap<FinishedSurveyAnswerModel, FinishedSurveyAnswer>();
            });
        }
    }
}