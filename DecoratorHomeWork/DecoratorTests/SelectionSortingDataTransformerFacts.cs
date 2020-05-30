using DecoratorHomeWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorTests
{
    /// <summary>
    /// Класс с тестами преобразователя-декоратора, сортирующего сортировкой простым выбором.
    /// </summary>
    public class SelectionSortingDataTransformerFacts : SortingDataTransformerFacts
    {
        protected override BaseSortingDataTransformer GetTestedTransformer()
        {
            return new SelectionSortingDataTransformer(new IdleDataTransformer());
        }
    }
}
