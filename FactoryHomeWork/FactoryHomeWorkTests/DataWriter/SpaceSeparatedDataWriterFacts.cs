using FactoryHomeWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWorkTests.DataWriter
{
    public class SpaceSeparatedDataWriterFacts : SeparatedDataWriterFacts
    {
        protected override SeparatedDataWriter GetTestedDataWriter(TextWriter writer)
        {
            return new SpaceSeparatedDataWriter(writer);
        }
    }
}
