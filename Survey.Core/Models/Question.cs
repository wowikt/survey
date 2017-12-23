using Survey.Core.Enums;
using Survey.Core.Interfaces;
using System.Collections.Generic;

namespace Survey.Core.Models
{
    /// <summary>
    /// Данные вопроса: модель уровня данных
    /// </summary>
    public class Question : IEntity
    {
        public int Id { get; set; }
        public int SurveyPlanId { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }

        public virtual SurveyPlan SurveyPlan { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
