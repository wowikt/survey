using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.App.Models
{
    /// <summary>
    /// Данные завершенного опроса: модель бизнес-уровня
    /// </summary>
    public class FinishedSurveyModel
    {
        public int Id { get; set; }
        public int SurveyPlanId { get; set; }
        public DateTime DateCreated { get; set; }

        public IList<FinishedSurveyAnswerModel> FinishedSurveyAnswers { get; set; }
    }
}
