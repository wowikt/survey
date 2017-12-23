using System.Collections.Generic;

namespace Survey.Web.Models
{
    /// <summary>
    /// Данные плана опроса: уровень вью-модели
    /// </summary>
    public class SurveyPlanViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<QuestionViewModel> QuestionModels { get; set; }
    }
}