using Survey.Core.Enums;
using System.Collections.Generic;

namespace Survey.Web.Models
{
    /// <summary>
    /// Данные вопроса завершенного опроса: уровень вью-модели
    /// </summary>
    public class FinishedSurveyQuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public IList<FinishedSurveyAnswerViewModel> Answers { get; set; }
    }
}