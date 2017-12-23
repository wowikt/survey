using Survey.Core.Models;
using Survey.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repository.SqlServer.Repositories
{
    /// <summary>
    /// Репозиторий завершенных опросов
    /// </summary>
    public class FinishedSurveyRepository : IFinishedSurveyRepository
    {
        /// <summary>
        /// Получение данных завершенного опроса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FinishedSurvey Get(int id)
        {
            using (var ctx = new SqlServerSurveyContext())
            {
                // При извлечении нужны данные всех уровней опроса, включая в том числе исходные ответы
                return ctx.FinishedSurveys.Include("FinishedSurveyAnswers.Answer")
                    .SingleOrDefault(fsa => fsa.Id == id);
            }
        }

        /// <summary>
        /// Не реализовано
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FinishedSurvey> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Сохранение завершенного опроса
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int SaveOrAdd(FinishedSurvey item)
        {
            using (var ctx = new SqlServerSurveyContext())
            {
                // Если в переданном объекте указан Id, пытаемся найти исходную запись
                if (item.Id != 0)
                {
                    var dbItem = ctx.FinishedSurveys.SingleOrDefault(q => q.Id == item.Id);
                    if (dbItem != null)
                    {
                        // Если таковая есть, меняем только поля, которые могут измениться
                        dbItem.SurveyPlanId = item.SurveyPlanId;
                        dbItem.DateCreated = item.DateCreated;
                        ctx.SaveChanges();
                        return item.Id;
                    }
                }

                // Если запись не найдена, добавляем ее
                ctx.FinishedSurveys.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }
        }
    }
}
