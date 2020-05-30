using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    public abstract class BaseSortingDataTransformer : IDataTransformer
    {
        protected IDataTransformer _innerTransformer;

        public BaseSortingDataTransformer(IDataTransformer innerTransformer)
        {
            _innerTransformer = innerTransformer ?? throw new ArgumentNullException(nameof(innerTransformer));
        }

        public string[] TransformData(string[] data)
        {
            var transformedData = _innerTransformer.TransformData(data);

            if (transformedData != null)
            {
                transformedData = SortData(transformedData);
            }

            return transformedData;
        }

        protected abstract string[] SortData(string[] data);

        protected void Swap(string[] data, int index1, int index2)
        {
            var temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
        }
    }
}