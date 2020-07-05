using RandomMatrixAddUtility;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RandomMatrixAddUtilityTests
{

    /// <summary>
    /// Класс с тестами логирующего прокси для адаптера сложения матриц.
    /// </summary>
    public class LoggingMatrixAddAdapterFacts
    {

        /// <summary>
        /// Проверить, что вызов метода сложения матриц вызывает логгер.
        /// </summary>
        [Fact]
        public void AddMatrixes_CallsLogger()
        {
            var fakeMatrixAddAdapter = new FakeMatrixAddAdapter();
            var loggerStub = new LoggerStub();
            var loggingAdapter = new LoggingMatrixAddAdapter(fakeMatrixAddAdapter, loggerStub);

            loggingAdapter.AddMatrixes("1.txt", "2.txt");

            Assert.True(loggerStub.IsCalled);
        }
    }
}
