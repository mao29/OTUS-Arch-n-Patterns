using FactoryHomeWork;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FactoryHomeWorkTests
{
    public class SeparatedSortedDataWriterFactoryFacts
    {
        [Fact]
        public void GetSortedDataWriter_TabSeparator_ReturnsTabSeparatedSortedDataWriter()
        {
            var actual = new SeparatedSortedDataWriterFactory().GetSortedDataWriter(Separator.Tab);

            Assert.IsType<TabSeparatedSortedDataWriter>(actual);
        }

        [Fact]
        public void GetSortedDataWriter_SpaceSeparator_ReturnsSpaceSeparatedSortedDataWriter()
        {
            var actual = new SeparatedSortedDataWriterFactory().GetSortedDataWriter(Separator.Space);

            Assert.IsType<SpaceSeparatedSortedDataWriter>(actual);
        }

        [Fact]
        public void GetSortedDataWriter_NewLineSeparator_ReturnsNewLineSeparatedSortedDataWriter()
        {
            var actual = new SeparatedSortedDataWriterFactory().GetSortedDataWriter(Separator.NewLine);

            Assert.IsType<NewLineSeparatedSortedDataWriter>(actual);
        }
    }
}
