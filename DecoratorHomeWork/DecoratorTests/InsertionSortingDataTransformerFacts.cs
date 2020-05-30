using DecoratorHomeWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorTests
{
    public class InsertionSortingDataTransformerFacts : SortingDataTransformerFacts
    {
        protected override BaseSortingDataTransformer GetTestedTransformer()
        {
            return new InsertionSortingDataTransformer(new IdleDataTransformer());
        }
    }
}
