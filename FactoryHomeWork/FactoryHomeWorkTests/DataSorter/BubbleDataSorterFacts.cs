using FactoryHomeWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryHomeWorkTests.DataSorter
{
    /// <summary>
    /// Класс с тестами сортировщика, сортирующего пузырьковой сортировкой.
    /// </summary>
    public class BubbleDataSorterFacts : DataSorterFacts
    {
        protected override BaseDataSorter GetTestedSorter()
        {
            return new BubbleDataSorter();
        }
    }
}
