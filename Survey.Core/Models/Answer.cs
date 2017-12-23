using Survey.Core.Interfaces;
using System.Collections.Generic;

namespace Survey.Core.Models
{
    /// <summary>
    /// Предлагаемый ответ на вопрос: модель уровня данных
    /// </summary>
    public class Answer : IEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<FinishedSurveyAnswer> FinishedSurveyAnswers { get; set; }
    }
}
