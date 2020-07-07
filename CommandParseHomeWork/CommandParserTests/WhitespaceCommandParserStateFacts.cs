using CommandParser;

using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class WhitespaceCommandParserStateFacts
    {
        [Fact]
        public void ProcessChar_Whitespace_ReturnsTrueAndTransitionsToAnyCharState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new WhitespaceCommandParserState(mock.Object);

            bool isValid = state.ProcessChar('_');

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.IsAny<AnyCharCommandParserState>()));
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
        public void ProcessChar_InvalidCharacter_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new WhitespaceCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_ReturnsTrueAndTransitionsToFinishedState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new WhitespaceCommandParserState(mock.Object);

            bool isValid = state.FinishProcessing();

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.IsAny<FinishedCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
