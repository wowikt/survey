using AutoMapper;
using Survey.App.Interfaces;
using Survey.App.Models;
using Survey.Core.Models;
using Survey.Core.Repositories;
using System.Linq;

namespace Survey.App.AppServices
{
    /// <summary>
    /// Сервия для работы с завершенными опросами
    /// </summary>
    public class FinishedSurveyService : IFinishedSurveyService
    {
        private readonly IFinishedSurveyRepository _finishedSurveyRepository;
        private readonly ISurveyPlanRepository _surveyPlanRepository;

        public FinishedSurveyService(IFinishedSurveyRepository finishedSurveyRepository,
            ISurveyPlanRepository surveyPlanRepository)
        {
            _finishedSurveyRepository = finishedSurveyRepository;
            _surveyPlanRepository = surveyPlanRepository;
        }

        /// <summary>
        /// Чтение завершенного опроса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FinishedSurveyModel GetFinishedSurvey(int id)
        {
            // Извлекаем данные из базы и маппим их на класс результата
            var finishedSurvey = _finishedSurveyRepository.Get(id);
            var result = Mapper.Map<FinishedSurveyModel>(finishedSurvey);

            // Не хватает формулировок вопросов. Чтобы их получить, извлекаем план опроса
            var surveyPlan = _surveyPlanRepository.Get(result.SurveyPlanId);
            foreach (var answer in result.FinishedSurveyAnswers)
            {
                // Извлекаем из плана очередной вопрос и добавляем его к ответу.
                //  Если его уже нет, создаем фиктивную запись.
                var planQuestion = surveyPlan.Questions.SingleOrDefault(q => q.Id == answer.QuestionId);
                if (planQuestion != null)
                {
                    answer.Question = Mapper.Map<QuestionModel>(planQuestion);
                }
                else
                {
                    answer.Question = new QuestionModel
                    {
                        Text = "Вопрос исключен из опроса"
                    };
                }
            }
            return result;
        }

        /// <summary>
        /// Сохранение завершенного опроса
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Save(FinishedSurveyModel model)
        {
            // Маппим на модель уровня данных и сохраняем
            var savedData = Mapper.Map<FinishedSurvey>(model);
            return _finishedSurveyRepository.SaveOrAdd(savedData);
        }
    }
}
