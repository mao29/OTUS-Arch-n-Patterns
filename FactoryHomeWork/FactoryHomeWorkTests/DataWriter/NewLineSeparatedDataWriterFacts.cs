using FactoryHomeWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWorkTests.DataWriter
{
    public class NewLineSeparatedDataWriterFacts : SeparatedDataWriterFacts
    {
        protected override SeparatedDataWriter GetTestedDataWriter(TextWriter writer)
        {
            return new NewLineSeparatedDataWriter(writer);
        }
    }
}
