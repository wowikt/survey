using Survey.Core.Interfaces;
using System.Collections.Generic;

namespace Survey.Core.Models
{
    /// <summary>
    /// План опроса: модель уровня данных
    /// </summary>
    public class SurveyPlan : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<FinishedSurvey> FinishedSurveys { get; set; }
    }
}
