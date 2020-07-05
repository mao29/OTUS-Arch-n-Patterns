using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateMethodHomeWork;
using Xunit;

namespace TemplateMethodHomeWorkTests
{
    /// <summary>
    /// Класс с тестами шаблонного метода обраотчика операции над матрицами.
    /// </summary>
    public class TemplateMethodFacts
    {
        /// <summary>
        /// Класс-заглушка для определения порядка вызова абстрактных методов.
        /// </summary>
        class MatrixProcessorStub : MatrixProcessor
        {
            public MatrixProcessorStub()
                : base("2.txt")
            { }

            /// <summary>
            /// Вызванные методы.
            /// </summary>
            public List<string> CalledMethods { get; set; } = new List<string>();

            protected override void ProcessData()
            {
                CalledMethods.Add(nameof(ProcessData));
            }

            protected override void ReadData()
            {
                CalledMethods.Add(nameof(ReadData));
            }

            protected override string[] TransformResultForWrite()
            {
                CalledMethods.Add(nameof(TransformResultForWrite));
                return null;
            }

            protected override void WriteResult(string[] result)
            {
                CalledMethods.Add(nameof(WriteResult));
            }
        }

        [Fact]
        public void DoProcessing_CallsAbstractMethodsInCorrectOrder()
        {
            var stubProcessor = new MatrixProcessorStub();

            stubProcessor.DoProcessing();

            Assert.Equal(new[] { "ReadData", "ProcessData", "TransformResultForWrite", "WriteResult" }, stubProcessor.CalledMethods);
        }
    }
}
