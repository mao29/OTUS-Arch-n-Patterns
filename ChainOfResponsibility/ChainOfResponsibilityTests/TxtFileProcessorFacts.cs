using ChainOfResponsibility;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChainOfResponsibilityTests
{
    public class TxtFileProcessorFacts
    {
        [Fact]
        public void TxtExtension_FileProcessed()
        {
            var filename = "file.txt";
            var loggerMock = new Mock<ILogger>();

            var processor = new TxtFileProcessor(loggerMock.Object);
            processor.ProcessFile(filename);

            loggerMock.Verify(x => x.WriteMessage("Обработчик TXT получил файл file.txt"));
        }

        [Fact]
        public void NotTxtExtension_FilePassedToNextProcessor()
        {
            var filename = "file.jpg";
            var loggerMock = new Mock<ILogger>();
            var nextProcessorMock = new Mock<IFileProcessor>();

            var processor = new TxtFileProcessor(loggerMock.Object);
            processor.SetNext(nextProcessorMock.Object);
            processor.ProcessFile(filename);

            nextProcessorMock.Verify(x => x.ProcessFile("file.jpg"));
        }
    }
}
