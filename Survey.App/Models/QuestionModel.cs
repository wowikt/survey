using Survey.Core.Enums;
using System.Collections.Generic;

namespace Survey.App.Models
{
    /// <summary>
    /// Данные вопроса: модель бизнес-уровня
    /// </summary>
    public class QuestionModel
    {
        public int Id { get; set; }
        public int SurveyPlanId { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }

        public virtual IList<AnswerModel> Answers { get; set; }
    }
}
