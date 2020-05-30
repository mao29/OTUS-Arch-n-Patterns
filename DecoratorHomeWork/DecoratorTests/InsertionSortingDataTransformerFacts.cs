using DecoratorHomeWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorTests
{
    /// <summary>
    /// Класс с тестами преобразователя-декоратора, сортирующего сортировкой простыми вставками.
    /// </summary>
    public class InsertionSortingDataTransformerFacts : SortingDataTransformerFacts
    {
        protected override BaseSortingDataTransformer GetTestedTransformer()
        {
            return new InsertionSortingDataTransformer(new IdleDataTransformer());
        }
    }
}
