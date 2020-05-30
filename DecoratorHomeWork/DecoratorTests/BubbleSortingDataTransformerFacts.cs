using DecoratorHomeWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorTests
{
    public class BubbleSortingDataTransformerFacts : SortingDataTransformerFacts
    {
        protected override BaseSortingDataTransformer GetTestedTransformer()
        {
            return new BubbleSortingDataTransformer(new IdleDataTransformer());
        }
    }
}
