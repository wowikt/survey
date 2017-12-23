namespace Survey.Web.Models
{
    /// <summary>
    /// Данные ответа: уровень вью-модели
    /// </summary>
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
    }
}