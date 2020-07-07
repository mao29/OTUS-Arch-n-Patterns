using CommandParser;

using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class WhitespaceAfterKeyCommandParserStateFacts
    {
        [Fact]
        public void ProcessChar_Whitespace_ReturnsTrueAndTransitionsToAnyCharAfterKeyState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new WhitespaceAfterKeyCommandParserState(mock.Object, "a");

            bool isValid = state.ProcessChar('_');

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.Is<AnyCharAfterKeyCommandParserState>(x => x.KeyName == "a")));
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

            var state = new WhitespaceAfterKeyCommandParserState(mock.Object, "a");

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_ReturnsTrueAndAddsKeyAndTransitionsToFinishedState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new WhitespaceAfterKeyCommandParserState(mock.Object, "a");

            bool isValid = state.FinishProcessing();

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandKey(It.Is<CommandKey>(x => x.Name == "a")));
            mock.Verify(x => x.SetState(It.IsAny<FinishedCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
