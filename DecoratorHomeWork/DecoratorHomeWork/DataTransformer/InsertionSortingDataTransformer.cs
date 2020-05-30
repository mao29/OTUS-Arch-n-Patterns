using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    public class InsertionSortingDataTransformer : BaseSortingDataTransformer
    {
        public InsertionSortingDataTransformer(IDataTransformer innerTransformer) : base(innerTransformer)
        { }

        protected override string[] SortData(string[] data)
        {
            return InsertionSort(data);
        }

        private string[] InsertionSort(string[] data)
        {
            var sortedData = data;

            int i = 1;
            while (i < sortedData.Length)
            {
                int j = i;
                while (j > 0 && sortedData[j - 1].CompareTo(sortedData[j]) > 0)
                {
                    Swap(sortedData, j - 1, j);
                    j--;
                }
                i++;
            }

            return sortedData;
        }
    }
}
