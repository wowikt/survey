using Survey.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Repositories
{
    /// <summary>
    /// Интерфейс репозитория для работы с завершенными опросами
    /// </summary>
    public interface IFinishedSurveyRepository : IRepository<FinishedSurvey>
    {
    }
}
