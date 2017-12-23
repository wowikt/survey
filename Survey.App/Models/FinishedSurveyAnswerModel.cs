using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.App.Models
{
    /// <summary>
    /// Данные ответа завершенного опроса: модель бизнес-уровня
    /// </summary>
    public class FinishedSurveyAnswerModel
    {
        public int Id { get; set; }
        public int? AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }

        public AnswerModel Answer { get; set; }
        public QuestionModel Question { get; set; }
    }
}
