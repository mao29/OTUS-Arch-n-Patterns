using ChainOfResponsibility;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChainOfResponsibilityTests
{
    public class XmlFileProcessorFacts
    {
        [Fact]
        public void XmlExtension_FileProcessed()
        {
            var filename = "file.xml";
            var loggerMock = new Mock<ILogger>();

            var processor = new XmlFileProcessor(loggerMock.Object);
            processor.ProcessFile(filename);

            loggerMock.Verify(x => x.WriteMessage("Обработчик XML получил файл file.xml"));
        }

        [Fact]
        public void NotXmlExtension_FilePassedToNextProcessor()
        {
            var filename = "file.jpg";
            var loggerMock = new Mock<ILogger>();
            var nextProcessorMock = new Mock<IFileProcessor>();

            var processor = new XmlFileProcessor(loggerMock.Object);
            processor.SetNext(nextProcessorMock.Object);
            processor.ProcessFile(filename);

            nextProcessorMock.Verify(x => x.ProcessFile("file.jpg"));
        }
    }
}
