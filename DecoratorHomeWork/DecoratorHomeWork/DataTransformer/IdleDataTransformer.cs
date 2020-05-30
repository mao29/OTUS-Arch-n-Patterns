using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    public class IdleDataTransformer : IDataTransformer
    {
        public string[] TransformData(string[] data)
        {
            return data;
        }
    }
}
