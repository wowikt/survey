namespace Survey.Web.Models
{
    /// <summary>
    /// Данные ответа завершенного опроса: уровень вью-модели
    /// </summary>
    public class FinishedSurveyAnswerViewModel
    {
        public int Id { get; set; }
        public int? AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
    }
}