using Survey.Core.Interfaces;

namespace Survey.Core.Models
{
    /// <summary>
    /// Данные об ответе завершенного опроса: модель уровня данных
    /// </summary>
    public class FinishedSurveyAnswer : IEntity
    {
        public int Id { get; set; }
        public int FinishedSurveyId { get; set; }
        public int? AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }

        public virtual FinishedSurvey FinishedSurvey { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
