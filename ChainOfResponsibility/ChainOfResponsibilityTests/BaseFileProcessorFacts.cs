using ChainOfResponsibility;
using Moq;
using System;
using Xunit;

namespace ChainOfResponsibilityTests
{
    public class BaseFileProcessorFacts
    {
        /// <summary>
        /// Обработчик файлов, который не подходит ни к одному файлу.
        /// </summary>
        class MismatchedFileProcessor : BaseFileProcessor
        {
            public MismatchedFileProcessor(ILogger logger) : base(logger)
            { }

            protected override bool CanHandle(string filePath)
            {
                return false;
            }

            protected override void DoProcessFile(string filePath)
            {
            }
        }

        /// <summary>
        /// Обработчик файлов, который срабатывает для любого файла.
        /// </summary>
        class MatchedFileProcessor : BaseFileProcessor
        {
            public bool IsDoProcessFileCalled
            {
                get;
                private set;
            }

            public MatchedFileProcessor(ILogger logger) : base(logger)
            { }

            protected override bool CanHandle(string filePath)
            {
                return true;
            }

            protected override void DoProcessFile(string filePath)
            {
                IsDoProcessFileCalled = true;
            }
        }

        [Fact]
        public void NoMathchedProcessor_NullProcessorIsProcessing()
        {
            var loggerMock = new Mock<ILogger>();

            var mismatchedFileProcessor = new MismatchedFileProcessor(loggerMock.Object);
            mismatchedFileProcessor.ProcessFile("someFilePath");

            loggerMock.Verify(x => x.WriteMessage("Обработчика для файла someFilePath не найдено."));
        }

        [Fact]
        public void MatchedProcessor_CorrectlyProcessing()
        {
            var loggerMock = new Mock<ILogger>();

            var matchedFileProcessor = new MatchedFileProcessor(loggerMock.Object);
            matchedFileProcessor.ProcessFile("someFilePath");

            Assert.True(matchedFileProcessor.IsDoProcessFileCalled, "Не вызвался метод обработки файла у подходящего обработчика.");
        }
    }
}
