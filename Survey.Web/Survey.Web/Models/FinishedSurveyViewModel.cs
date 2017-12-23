using System;
using System.Collections.Generic;

namespace Survey.Web.Models
{
    /// <summary>
    /// Данные завершенного опроса: уровень вью-модели
    /// </summary>
    public class FinishedSurveyViewModel
    {
        public int Id { get; set; }
        public int SurveyPlanId { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<FinishedSurveyQuestionViewModel> Questions { get; set; }
    }
}