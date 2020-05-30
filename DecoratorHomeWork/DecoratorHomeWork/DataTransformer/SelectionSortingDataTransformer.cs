using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    public class SelectionSortingDataTransformer : BaseSortingDataTransformer
    {
        public SelectionSortingDataTransformer(IDataTransformer innerTransformer) : base(innerTransformer)
        { }

        protected override string[] SortData(string[] data)
        {
            return SelectionSort(data);
        }

        private string[] SelectionSort(string[] data)
        {
            var sortedData = data;

            for (int i = 0; i < sortedData.Length - 1; i++)
            {
                int jMin = i;
                for (int j = i + 1; j < sortedData.Length; j++)
                {
                    if (sortedData[j].CompareTo(sortedData[jMin]) < 0)
                    {
                        jMin = j;
                    }
                }

                if (jMin != i)
                {
                    Swap(sortedData, i, jMin);
                }
            }

            return sortedData;
        }
    }
}
