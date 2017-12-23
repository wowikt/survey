using AutoMapper;
using Survey.App.Interfaces;
using Survey.App.Models;
using Survey.Core.Repositories;
using System.Collections.Generic;

namespace Survey.App.AppServices
{
    /// <summary>
    /// Сервис для работы с планами опросов
    /// </summary>
    public class SurveyPlanService : ISurveyPlanService
    {
        private readonly ISurveyPlanRepository _surveyPlanRepository;

        public SurveyPlanService(ISurveyPlanRepository surveyPlanRepository)
        {
            _surveyPlanRepository = surveyPlanRepository;
        }

        /// <summary>
        /// Получение всех планов (только записи верхнего уровня)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SurveyPlanModel> GetAll()
        {
            return Mapper.Map<List<SurveyPlanModel>>(_surveyPlanRepository.GetAll());
        }

        /// <summary>
        /// Получение плана опроса с данными всех уровней
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SurveyPlanModel GetSurveyPlanModel(int id)
        {
            var dbData = _surveyPlanRepository.Get(id);
            var result = Mapper.Map<SurveyPlanModel>(dbData);

            // Вопросы маппятся отдельно, т. к. их маппинг по умолчанию отключен
            //  посредством указания разных имен свойств, во избежание ошибок
            //  при извлечении списка всех опросов
            result.QuestionModels = Mapper.Map<List<QuestionModel>>(dbData.Questions);
            return result;
        }
    }
}
