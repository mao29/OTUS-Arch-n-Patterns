using DecoratorHomeWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorTests
{
    public class SelectionSortingDataTransformerFacts : SortingDataTransformerFacts
    {
        protected override BaseSortingDataTransformer GetTestedTransformer()
        {
            return new SelectionSortingDataTransformer(new IdleDataTransformer());
        }
    }
}
