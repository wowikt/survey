using Survey.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.App.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса планов опросов
    /// </summary>
    public interface ISurveyPlanService
    {
        IEnumerable<SurveyPlanModel> GetAll();

        SurveyPlanModel GetSurveyPlanModel(int id);
    }
}
