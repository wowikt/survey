using Survey.Core.Enums;
using System.Collections.Generic;

namespace Survey.Web.Models
{
    /// <summary>
    /// Данные вопроса: уровень вью-модели
    /// </summary>
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public int SelectedIndex { get; set; }

        public IList<AnswerViewModel> Answers { get; set; }
    }
}