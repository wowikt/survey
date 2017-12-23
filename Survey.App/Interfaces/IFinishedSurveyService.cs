using Survey.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.App.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса завершенных опросов
    /// </summary>
    public interface IFinishedSurveyService
    {
        int Save(FinishedSurveyModel model);
        FinishedSurveyModel GetFinishedSurvey(int id);
    }
}
