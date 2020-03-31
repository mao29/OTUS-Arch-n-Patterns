using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString.Tests
{
    class NoResizeArrayResizerStub<T> : IArrayResizer<T>
    {
        public bool CanDecreaseArray(int arrayLength, int currentSaturation)
        {
            return false;
        }

        public bool CanIncreaseArray(int arrayLength, int currentSaturation)
        {
            return false;
        }

        public T[] DecreaseArray(T[] sourceArray, int currentSaturation)
        {
            throw new NotImplementedException();
        }

        public T[] IncreaseArray(T[] sourceArray, int currentSaturation)
        {
            throw new NotImplementedException();
        }
    }
}
