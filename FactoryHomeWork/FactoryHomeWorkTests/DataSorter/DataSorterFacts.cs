using FactoryHomeWork;
using System;
using Xunit;

namespace FactoryHomeWorkTests.DataSorter
{
    /// <summary>
    /// Базовый класс с тестами сортирующих преобразователей данных.
    /// </summary>
    public abstract class DataSorterFacts
    {
        /// <summary>
        /// Получить сортирующий декоратор-преобразователь данных.
        /// </summary>
        /// <returns></returns>
        protected abstract BaseDataSorter GetTestedSorter();

        [Fact]
        public void SortData_EmptyData_Correct()
        {
            var sorter = GetTestedSorter();

            var data = new string[0];

            var actual = sorter.SortData(data);

            Assert.Equal(data, actual);
        }
        
        [Fact]
        public void SortData_OneElement_Correct()
        {
            var sorter = GetTestedSorter();

            string[] data = new string[] { "str1" };

            var actual = sorter.SortData(data);

            Assert.Equal(data, actual);
        }

        [Fact]
        public void SortData_TwoElementsUnsorted_Correct()
        {
            var sorter = GetTestedSorter();

            string[] data = new string[] { "xyz", "abc" };
            string[] expected = new string[] { "abc", "xyz" };

            var actual = sorter.SortData(data);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortData_TwoElementsSorted_Correct()
        {
            var sorter = GetTestedSorter();

            string[] data = new string[] { "abc", "xyz" };
            string[] expected = new string[] { "abc", "xyz" };

            var actual = sorter.SortData(data);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortData_ThreeDistinctElements_Correct()
        {
            var sorter = GetTestedSorter();

            string[] data = new string[] { "aaa", "xxx", "hhh" };
            string[] expected = new string[] { "aaa", "hhh", "xxx" };

            var actual = sorter.SortData(data);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortData_ThreeNonDistinctElements_Correct()
        {
            var sorter = GetTestedSorter();

            string[] data = new string[] { "aaa", "xxx", "aaa" };
            string[] expected = new string[] { "aaa", "aaa", "xxx" };

            var actual = sorter.SortData(data);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SortData_ManyElements_Correct()
        {
            var sorter = GetTestedSorter();

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

            var actual = sorter.SortData(data);

            Assert.Equal(expected, actual);
        }
    }
}
