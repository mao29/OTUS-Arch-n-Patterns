﻿using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class QuotedCommandParameterFirstCharCommandParserStateFacts
    {
        [Theory]
        [InlineData('a')]
        [InlineData('B')]
        [InlineData('2')]
        [InlineData('_')]
        public void ProcessChar_ValidCharacter_ReturnsTrue(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedCommandParameterFirstCharCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.IsAny<QuotedCommandParameterCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('ф')]
        [InlineData('\\')]
        [InlineData(' ')]
        [InlineData('"')]
        public void ProcessChar_InvalidCharacter_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedCommandParameterFirstCharCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_ReturnsFalseAndTransitionsToInvalidState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedCommandParameterFirstCharCommandParserState(mock.Object);

            bool isValid = state.FinishProcessing();

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
