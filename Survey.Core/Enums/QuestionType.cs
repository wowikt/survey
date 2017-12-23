using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Enums
{
    /// <summary>
    /// Тип вопроса
    /// </summary>
    public enum QuestionType
    {
        /// <summary>
        /// Нет типа
        /// </summary>
        None,

        /// <summary>
        /// Закрытый с одиночным выбором (реализован посредством radiobuttons)
        /// </summary>
        ClosedSingle,

        /// <summary>
        /// Закрытый с множественным выбором (реализован посредством checkboxes)
        /// </summary>
        ClosedMultiple,

        /// <summary>
        /// Открытый (содержит поле для свободного ввода ответа)
        /// </summary>
        Open,
    }
}
