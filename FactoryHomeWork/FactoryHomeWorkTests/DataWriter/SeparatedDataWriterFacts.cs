using FactoryHomeWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace FactoryHomeWorkTests.DataWriter
{
    /// <summary>
    /// Базовый класс с тестами писателя данных с разделителем.
    /// </summary>
    public abstract class SeparatedDataWriterFacts
    {
        /// <summary>
        /// Получить тестируемый конкретный писатель данных с разделителем.
        /// </summary>
        /// <param name="writer">Поток записи.</param>
        /// <returns>Тестируемый конкретный писатель данных с разделителем.</returns>
        protected abstract SeparatedDataWriter GetTestedDataWriter(TextWriter writer);

        [Fact]
        public void WriteData_NullData_WritesNothing()
        {
            StringBuilder sb = new StringBuilder();
            var writer = new StringWriter(sb);

            var dataWriter = GetTestedDataWriter(writer);

            dataWriter.WriteData(null);

            Assert.Empty(sb.ToString());
        }

        [Fact]
        public void WriteData_EmptyData_WritesNothing()
        {
            StringBuilder sb = new StringBuilder();
            var writer = new StringWriter(sb);

            var dataWriter = GetTestedDataWriter(writer);

            dataWriter.WriteData(new string[0]);

            Assert.Empty(sb.ToString());
        }

        [Fact]
        public void WriteData_SingleElement_Correct()
        {
            StringBuilder sb = new StringBuilder();
            var writer = new StringWriter(sb);

            var dataWriter = GetTestedDataWriter(writer);

            dataWriter.WriteData(new[] { "aaa" });

            Assert.Equal("aaa", sb.ToString());
        }

        [Fact]
        public void WriteData_TwoElements_Correct()
        {
            StringBuilder sb = new StringBuilder();
            var writer = new StringWriter(sb);

            var dataWriter = GetTestedDataWriter(writer);

            dataWriter.WriteData(new[] { "aaa", "bbb" });

            Assert.Equal("aaa" + dataWriter.Separator + "bbb", sb.ToString());
        }

        [Fact]
        public void WriteData_ThreeElements_Correct()
        {
            StringBuilder sb = new StringBuilder();
            var writer = new StringWriter(sb);

            var dataWriter = GetTestedDataWriter(writer);

            dataWriter.WriteData(new[] { "aaa", "bbb", "ccc" });

            Assert.Equal("aaa" + dataWriter.Separator + "bbb" + dataWriter.Separator + "ccc", sb.ToString());
        }
    }
}
