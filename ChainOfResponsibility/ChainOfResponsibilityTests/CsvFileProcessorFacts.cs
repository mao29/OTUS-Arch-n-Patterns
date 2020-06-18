using ChainOfResponsibility;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChainOfResponsibilityTests
{
    public class CsvFileProcessorFacts
    {
        [Fact]
        public void CsvExtension_FileProcessed()
        {
            var filename = "file.csv";
            var loggerMock = new Mock<ILogger>();

            var processor = new CsvFileProcessor(loggerMock.Object);
            processor.ProcessFile(filename);

            loggerMock.Verify(x => x.WriteMessage("Обработчик CSV получил файл file.csv"));
        }

        [Fact]
        public void NotCsvExtension_FilePassedToNextProcessor()
        {
            var filename = "file.jpg";
            var loggerMock = new Mock<ILogger>();
            var nextProcessorMock = new Mock<IFileProcessor>();

            var processor = new CsvFileProcessor(loggerMock.Object);
            processor.SetNext(nextProcessorMock.Object);
            processor.ProcessFile(filename);

            nextProcessorMock.Verify(x => x.ProcessFile("file.jpg"));
        }
    }
}
