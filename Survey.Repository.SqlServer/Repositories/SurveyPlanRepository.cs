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
    /// Репозиторий планов опросов
    /// </summary>
    public class SurveyPlanRepository : ISurveyPlanRepository
    {
        /// <summary>
        /// Получение данных плана опроса
        /// </summary>
        public SurveyPlan Get(int id)
        {
            using (var ctx = new SqlServerSurveyContext())
            {
                // При извлечении нужны данные всех уровней опроса, включая в том числе ответы
                return ctx.SurveyPlans.Include("Questions.Answers").SingleOrDefault(sp => sp.Id == id);
            }
        }

        /// <summary>
        /// Получение всех опросов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SurveyPlan> GetAll()
        {
            using (var ctx = new SqlServerSurveyContext())
            {
                return ctx.SurveyPlans.ToList();
            }
        }

        /// <summary>
        /// Сохранение плана опроса (в проекте не используется)
        /// </summary>
        public int SaveOrAdd(SurveyPlan item)
        {
            using (var ctx = new SqlServerSurveyContext())
            {
                // Если в переданном объекте указан Id, пытаемся найти исходную запись
                if (item.Id != 0)
                {
                    var dbItem = ctx.SurveyPlans.SingleOrDefault(sp => sp.Id == item.Id);
                    if (dbItem != null)
                    {
                        // Если таковая есть, меняем только поля, которые могут измениться
                        dbItem.Name = item.Name;
                        ctx.SaveChanges();
                        return item.Id;
                    }
                }

                // Если запись не найдена, добавляем ее
                ctx.SurveyPlans.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }
        }
    }
}
