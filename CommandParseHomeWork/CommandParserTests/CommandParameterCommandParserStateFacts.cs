using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class CommandParameterCommandParserStateFacts
    {
        [Theory]
        [InlineData('a')]
        [InlineData('B')]
        [InlineData('2')]
        public void ProcessChar_ValidCharacter_ReturnsTrue(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandParameterCommandParserState(mock.Object, 'a');

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

            var state = new CommandParameterCommandParserState(mock.Object, 'a');

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_Whitespace_AddsParameterAndTransitionsToAnyCharState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandParameterCommandParserState(mock.Object, 'a');

            bool isValid = state.ProcessChar('_');

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandParameter("a"));
            mock.Verify(x => x.SetState(It.IsAny<AnyCharCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_NoCharacters_ReturnsTrueAndAddsParameterAndTransitionsToFinishedState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandParameterCommandParserState(mock.Object, 'a');

            bool isValid = state.FinishProcessing();

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandParameter("a"));
            mock.Verify(x => x.SetState(It.IsAny<FinishedCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_AnyCharacters_ReturnsTrueAndAddsParameterAndTransitionsToFinishedState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandParameterCommandParserState(mock.Object, 'a');
            state.ProcessChar('b');

            bool isValid = state.FinishProcessing();

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandParameter("ab"));
            mock.Verify(x => x.SetState(It.IsAny<FinishedCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
