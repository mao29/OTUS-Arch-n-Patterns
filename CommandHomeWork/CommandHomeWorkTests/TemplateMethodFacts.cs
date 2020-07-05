using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CommandHomeWork;
using Xunit;

namespace CommandHomeWorkTests
{
    /// <summary>
    /// Класс с тестами шаблонного метода обраотчика операции над матрицами.
    /// </summary>
    public class TemplateMethodFacts
    {
        /// <summary>
        /// Класс-заглушка для определения порядка вызова абстрактных методов.
        /// </summary>
        class MatrixProcessorStub : MatrixProcessor, ICommand
        {
            public MatrixProcessorStub()
                : base("2.txt")
            { }

            /// <summary>
            /// Вызванные методы.
            /// </summary>
            public List<string> CalledMethods { get; set; } = new List<string>();

            public void Execute()
            {
                CalledMethods.Add(nameof(Execute));
            }

            public string[] GetResult()
            {
                CalledMethods.Add(nameof(GetResult));
                return null;
            }

            protected override ICommand ReadDataAndCreateCommand()
            {
                CalledMethods.Add(nameof(ReadDataAndCreateCommand));
                return this;
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

            Assert.Equal(new[] { "ReadDataAndCreateCommand", "Execute", "GetResult", "WriteResult" }, stubProcessor.CalledMethods);
        }
    }
}
