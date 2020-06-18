using ChainOfResponsibility;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChainOfResponsibilityTests
{
    public class JsonFileProcessorFacts
    {
        [Fact]
        public void JsonExtension_FileProcessed()
        {
            var filename = "file.json";
            var loggerMock = new Mock<ILogger>();

            var processor = new JsonFileProcessor(loggerMock.Object);
            processor.ProcessFile(filename);

            loggerMock.Verify(x => x.WriteMessage("Обработчик JSON получил файл file.json"));
        }

        [Fact]
        public void NotJsonExtension_FilePassedToNextProcessor()
        {
            var filename = "file.jpg";
            var loggerMock = new Mock<ILogger>();
            var nextProcessorMock = new Mock<IFileProcessor>();

            var processor = new JsonFileProcessor(loggerMock.Object);
            processor.SetNext(nextProcessorMock.Object);
            processor.ProcessFile(filename);

            nextProcessorMock.Verify(x => x.ProcessFile("file.jpg"));
        }
    }
}
