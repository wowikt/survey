using Survey.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Survey.Core.Models
{
    /// <summary>
    /// Данные о завершенном опросе: модель уровня данных
    /// </summary>
    public class FinishedSurvey : IEntity
    {
        public int Id { get; set; }
        public int SurveyPlanId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual SurveyPlan SurveyPlan { get; set; }
        public virtual ICollection<FinishedSurveyAnswer> FinishedSurveyAnswers { get; set; }
    }
}
