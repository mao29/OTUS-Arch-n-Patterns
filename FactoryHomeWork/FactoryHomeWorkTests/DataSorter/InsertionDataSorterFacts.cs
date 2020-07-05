using FactoryHomeWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryHomeWorkTests.DataSorter
{
    /// <summary>
    /// Класс с тестами преобразователя-декоратора, сортирующего сортировкой простыми вставками.
    /// </summary>
    public class InsertionDataSorterFacts : DataSorterFacts
    {
        protected override BaseDataSorter GetTestedSorter()
        {
            return new InsertionDataSorter();
        }
    }
}
