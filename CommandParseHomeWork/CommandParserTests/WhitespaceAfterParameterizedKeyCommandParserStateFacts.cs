using CommandParser;

using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class WhitespaceAfterParameterizedKeyCommandParserStateFacts
    {
        [Fact]
        public void ProcessChar_Whitespace_ReturnsTrueAndTransitionsToAnyCharAfterParameterizedKeyState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new WhitespaceAfterParameterizedKeyCommandParserState(mock.Object, "a");

            bool isValid = state.ProcessChar('_');

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.Is<AnyCharAfterParameterizedKeyCommandParserState>(x => x.KeyName == "a")));
            mock.VerifyNoOtherCalls();
        }
       
        [Theory]
        [InlineData('ф')]
        [InlineData('a')]
        [InlineData('B')]
        [InlineData('-')]
        [InlineData('3')]
        [InlineData('\\')]
        [InlineData(' ')]
        [InlineData('"')]
        public void ProcessChar_FirstCharNotWhitespace_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new WhitespaceAfterParameterizedKeyCommandParserState(mock.Object, "a");

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_ReturnsFalseAndTransitionsToInvalidState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new WhitespaceAfterParameterizedKeyCommandParserState(mock.Object, "a");

            bool isValid = state.FinishProcessing();

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
