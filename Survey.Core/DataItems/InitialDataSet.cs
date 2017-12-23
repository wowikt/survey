using Survey.Core.Models;
using System.Collections.Generic;

namespace Survey.Core.DataItems
{
    /// <summary>
    /// Набор данных для инициализации БД (sseding)
    /// </summary>
    public static class InitialDataSet
    {
        /// <summary>
        /// Возврашает исходный набор
        /// </summary>
        /// <returns></returns>
        public static ICollection<SurveyPlan>GetInitialData()
        {
            return new List<SurveyPlan>
            {
                new SurveyPlan
                {
                    Name = "Опрос 1",
                    Description = "Пройдите первый опрос",
                    Questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "Вопрос 1",
                            Type = Enums.QuestionType.ClosedMultiple,
                            Answers = new List<Answer>
                            {
                                new Answer
                                {
                                    Text = "Ответ 1"
                                },
                                new Answer
                                {
                                    Text = "Ответ 2"
                                },
                                new Answer
                                {
                                    Text = "Ответ 3"
                                },
                                new Answer
                                {
                                    Text = "Ответ 4"
                                },
                            }
                        },
                        new Question
                        {
                            Text = "Вопрос 2",
                            Type = Enums.QuestionType.ClosedSingle,
                            Answers = new List<Answer>
                            {
                                new Answer
                                {
                                    Text = "Ответ 1"
                                },
                                new Answer
                                {
                                    Text = "Ответ 2"
                                },
                                new Answer
                                {
                                    Text = "Ответ 3"
                                },
                            }
                        },
                         new Question
                        {
                            Text = "Вопрос 3",
                            Type = Enums.QuestionType.Open,
                        },
                    }
                }
            };
        }
    }
}
