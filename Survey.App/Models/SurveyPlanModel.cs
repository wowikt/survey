﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.App.Models
{
    /// <summary>
    /// Данные плана опроса: модель бизнес-уровня
    /// </summary>
    public class SurveyPlanModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<QuestionModel> QuestionModels { get; set; }
        public IList<FinishedSurveyModel> FinishedSurveyModels { get; set; }
    }
}
