using DecoratorHomeWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorTests
{
    /// <summary>
    /// Класс с тестами преобразователя-декоратора, сортирующего пузырьковой сортировкой.
    /// </summary>
    public class BubbleSortingDataTransformerFacts : SortingDataTransformerFacts
    {
        protected override BaseSortingDataTransformer GetTestedTransformer()
        {
            return new BubbleSortingDataTransformer(new IdleDataTransformer());
        }
    }
}
