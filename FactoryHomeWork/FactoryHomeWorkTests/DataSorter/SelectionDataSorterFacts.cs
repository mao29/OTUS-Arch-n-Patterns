using FactoryHomeWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryHomeWorkTests.DataSorter
{
    /// <summary>
    /// Класс с тестами преобразователя-декоратора, сортирующего сортировкой простым выбором.
    /// </summary>
    public class SelectionDataSorterFacts : DataSorterFacts
    {
        protected override BaseDataSorter GetTestedSorter()
        {
            return new SelectionDataSorter();
        }
    }
}
