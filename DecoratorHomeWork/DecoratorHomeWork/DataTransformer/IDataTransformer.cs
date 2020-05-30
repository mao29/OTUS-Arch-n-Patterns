using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    public interface IDataTransformer
    {
        string[] TransformData(string[] data);
    }
}
