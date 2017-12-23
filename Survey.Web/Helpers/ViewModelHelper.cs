using Survey.App.Models;
using Survey.Core.Enums;
using Survey.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survey.Web.Helpers
{
    /// <summary>
    /// Класс со вспомогательными процедурами уровня вью-модели
    /// </summary>
    public static class ViewModelHelper
    {
        /// <summary>
        /// Подготовка вью-модели опроса перед отображением
        /// </summary>
        /// <param name="model"></param>
        public static void PrepareSurveyPlanViewModel(SurveyPlanViewModel model)
        {
            // Для открытых вопросов надо добавить пустой ответ, куда будет записываться результат
            foreach (var question in model.QuestionModels.Where(q => q.Type == QuestionType.Open))
            {
                question.Answers = new List<AnswerViewModel> { new AnswerViewModel() };
            }

            // Для закрытых вопросов одиночного выбора указываем, что изначально ни один ответ не выбран
            foreach (var question in model.QuestionModels.Where(q => q.Type == QuestionType.ClosedSingle))
            {
                question.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Слияние вью-моделей планов опросов
        /// </summary>
        /// <param name="dbModel">Вью-модель плана опроса, извлеченный из БД</param>
        /// <param name="inputModel">Вью-модель плана опроса, полученная в контроллере</param>
        public static void MergeSurveyPlanViewModels(SurveyPlanViewModel dbModel, SurveyPlanViewModel inputModel)
        {
            foreach (var question in dbModel.QuestionModels)
            {
                var inputQuestion = inputModel.QuestionModels.SingleOrDefault(q => q.Id == question.Id);

                // Вообще, такого быть не должно, это ошибка
                if (inputQuestion == null)
                {
                    continue;
                }

                // Обработка в зависимости от типа вопроса
                switch (question.Type)
                {
                    case QuestionType.ClosedSingle:
                        if (inputQuestion.SelectedIndex >= 0)
                        {
                            // Если в полученной модели выбран ответ, записать его
                            question.SelectedIndex = inputQuestion.SelectedIndex;
                        }

                        break;
                    case QuestionType.ClosedMultiple:
                        foreach (var answer in question.Answers)
                        {
                            // Перебрать все ответы полученной модели и записать, какие из них выбраны
                            var inputAnswer = inputQuestion.Answers.SingleOrDefault(a => a.Id == answer.Id);
                            if (inputAnswer != null)
                            {
                                answer.IsSelected = inputAnswer.IsSelected;
                            }
                        }

                        break;
                    case QuestionType.Open:
                        if (inputQuestion.Answers != null && inputQuestion.Answers.Count > 0)
                        {
                            // Записать введенный ответ
                            question.Answers[0].Text = inputQuestion.Answers[0].Text;
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Построение бизнес-модели завершенного опроса из вью-модели плана опроса для сохранения
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FinishedSurveyModel CreateFinishedSurveyModel(SurveyPlanViewModel model)
        {
            var result = new FinishedSurveyModel
            {
                SurveyPlanId = model.Id,
                DateCreated = DateTime.Now,
                FinishedSurveyAnswers = new List<FinishedSurveyAnswerModel>()
            };

            foreach (var question in model.QuestionModels)
            {
                switch (question.Type)
                {
                    case QuestionType.ClosedSingle:
                        {
                            // Для закрытого вопроса одиночного выбора находим
                            //  выбранный ответ и сохраняем его данные
                            int idx = question.SelectedIndex;
                            var answer = question.Answers[idx];
                            result.FinishedSurveyAnswers.Add(new FinishedSurveyAnswerModel
                            {
                                AnswerId = answer.Id,
                                AnswerText = answer.Text,
                                QuestionId = question.Id,
                            });
                        }
                        break;
                    case QuestionType.ClosedMultiple:
                        foreach (var answer in question.Answers)
                        {
                            // Для закрытого вопроса множественного выбора находим
                            //  все выбранные ответы и сохраняем их данные
                            if (answer.IsSelected)
                            {
                                result.FinishedSurveyAnswers.Add(new FinishedSurveyAnswerModel
                                {
                                    AnswerId = answer.Id,
                                    AnswerText = answer.Text,
                                    QuestionId = question.Id,
                                });
                            }
                        }
                        break;
                    case QuestionType.Open:
                        // Для открытого вопроса созраняем данные ответа
                        result.FinishedSurveyAnswers.Add(new FinishedSurveyAnswerModel
                        {
                            AnswerText = question.Answers[0].Text,
                            QuestionId = question.Id,
                        });
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Построение вью-модели завершенного опроса из бизнес-модели
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FinishedSurveyViewModel CreateFinishedSurveyViewModel(FinishedSurveyModel model)
        {
            var result = new FinishedSurveyViewModel
            {
                Id = model.Id,
                SurveyPlanId = model.SurveyPlanId,
                DateCreated = model.DateCreated,
                Questions = new List<FinishedSurveyQuestionViewModel>()
            };

            // Выбираем все id вопросов
            var questionIds = model.FinishedSurveyAnswers.Select(a => a.QuestionId).Distinct().ToList();

            foreach (var id in questionIds)
            {
                // Для каждого id вопроса:
                //  1. Собираем содержимое вопроса
                var modelQuestion = model.FinishedSurveyAnswers.First(a => a.QuestionId == id)
                    .Question;
                var question = new FinishedSurveyQuestionViewModel
                {
                    Id = id,
                    Text = modelQuestion.Text,
                    Type = modelQuestion.Type,
                    Answers = new List<FinishedSurveyAnswerViewModel>()
                };

                //  2. Собираем все ответы на этот вопрос
                foreach (var answer in model.FinishedSurveyAnswers.Where(a => a.QuestionId == id))
                {
                    question.Answers.Add(new FinishedSurveyAnswerViewModel
                    {
                        Id = answer.Id,
                        AnswerText = answer.AnswerText,
                        AnswerId = answer.AnswerId,
                        QuestionId = answer.QuestionId,
                    });
                }

                result.Questions.Add(question);
            }

            return result;
        }
    }
}