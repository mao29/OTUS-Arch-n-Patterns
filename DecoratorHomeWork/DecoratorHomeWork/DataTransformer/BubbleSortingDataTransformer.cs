using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    public class BubbleSortingDataTransformer : BaseSortingDataTransformer
    {
        public BubbleSortingDataTransformer(IDataTransformer innerTransformer) : base(innerTransformer)
        { }

        protected override string[] SortData(string[] data)
        {
            return BubbleSort(data);
        }

        private string[] BubbleSort(string[] data)
        {
            var sortedData = data;

            var n = data.Length;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (data[i - 1].CompareTo(data[i]) > 0)
                    {
                        Swap(sortedData, i - 1, i);
                        swapped = true;
                    }
                }
            }
            while (swapped);

            return sortedData;
        }        
    }
}
