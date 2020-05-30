using DecoratorHomeWork;
using System;
using Xunit;

namespace DecoratorTests
{
    public abstract class SortingDataTransformerFacts
    {
        protected abstract BaseSortingDataTransformer GetTestedTransformer();

        [Fact]
        public void TransformData_EmptyData_Correct()
        {
            var transformer = GetTestedTransformer();

            var data = new string[0];

            var actual = transformer.TransformData(data);

            Assert.Equal(data, actual);
        }

        [Fact]
        public void TransformData_NullData_Correct()
        {
            var transformer = GetTestedTransformer();

            string[] data = null;

            var actual = transformer.TransformData(data);

            Assert.Null(actual);
        }

        [Fact]
        public void TransformData_OneElement_Correct()
        {
            var transformer = GetTestedTransformer();

            string[] data = new string[] { "str1" };

            var actual = transformer.TransformData(data);

            Assert.Equal(data, actual);
        }

        [Fact]
        public void TransformData_TwoElementsUnsorted_Correct()
        {
            var transformer = GetTestedTransformer();

            string[] data = new string[] { "xyz", "abc" };
            string[] expected = new string[] { "abc", "xyz" };

            var actual = transformer.TransformData(data);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformData_TwoElementsSorted_Correct()
        {
            var transformer = GetTestedTransformer();

            string[] data = new string[] { "abc", "xyz" };
            string[] expected = new string[] { "abc", "xyz" };

            var actual = transformer.TransformData(data);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformData_ThreeDistinctElements_Correct()
        {
            var transformer = GetTestedTransformer();

            string[] data = new string[] { "aaa", "xxx", "hhh" };
            string[] expected = new string[] { "aaa", "hhh", "xxx" };

            var actual = transformer.TransformData(data);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformData_ThreeNonDistinctElements_Correct()
        {
            var transformer = GetTestedTransformer();

            string[] data = new string[] { "aaa", "xxx", "aaa" };
            string[] expected = new string[] { "aaa", "aaa", "xxx" };

            var actual = transformer.TransformData(data);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformData_ManyElements_Correct()
        {
            var transformer = GetTestedTransformer();

            string[] data = new string[]
            {
                "ddd",
                "rhddd",
                "ddhga2d",
                "tu3ead",
                "aa",
                "qefgd",
                "ddd",
                "eqtrq",
                "freujy",
                "ccc",
                "qlbfhp"
            };

            string[] expected = new string[]
            {
                "aa",
                "ccc",
                "ddd",
                "ddd",
                "ddhga2d",
                "eqtrq",
                "freujy",
                "qefgd",
                "qlbfhp",
                "rhddd",
                "tu3ead"
            };

            var actual = transformer.TransformData(data);

            Assert.Equal(expected, actual);
        }
    }
}
