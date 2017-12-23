using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.App.Models
{
    /// <summary>
    /// Данные вопроса: модель бизнес-уровня
    /// </summary>
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public virtual IList<FinishedSurveyAnswerModel> FinishedSurveyAnswerModels { get; set; }
    }
}
