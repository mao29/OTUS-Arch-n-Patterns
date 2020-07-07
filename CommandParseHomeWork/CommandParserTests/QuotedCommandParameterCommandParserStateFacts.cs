using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class QuotedCommandParameterCommandParserStateFacts
    {
        [Theory]
        [InlineData('a')]
        [InlineData('B')]
        [InlineData('2')]
        [InlineData('_')]
        public void ProcessChar_ValidCharacter_ReturnsTrue(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedCommandParameterCommandParserState(mock.Object, 'a');

            bool isValid = state.ProcessChar(character);

            Assert.True(isValid);
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('ф')]
        [InlineData('\\')]
        [InlineData(' ')]
        public void ProcessChar_InvalidCharacter_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedCommandParameterCommandParserState(mock.Object, 'a');

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_LastQuote_AddsParameterAndTransitionsToWhitespaceState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedCommandParameterCommandParserState(mock.Object, 'a');
            state.ProcessChar('b');

            bool isValid = state.ProcessChar('"');

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandParameter("ab"));
            mock.Verify(x => x.SetState(It.IsAny<WhitespaceCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_FirstQuote_AddsParameterAndTransitionsToWhitespaceState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedCommandParameterCommandParserState(mock.Object, 'a');

            bool isValid = state.ProcessChar('"');

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandParameter("a"));
            mock.Verify(x => x.SetState(It.IsAny<WhitespaceCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_ReturnsFalseAndTransitionsToInvalidState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedCommandParameterCommandParserState(mock.Object, 'a');

            bool isValid = state.FinishProcessing();

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
