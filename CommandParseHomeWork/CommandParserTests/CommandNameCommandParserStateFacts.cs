using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class CommandNameCommandParserStateFacts
    {
        [Theory]
        [InlineData('a')]
        [InlineData('B')]
        public void ProcessChar_ValidCharacter_ReturnsTrue(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandNameCommandParserState(mock.Object, 'a');

            bool isValid = state.ProcessChar(character);

            Assert.True(isValid);
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('0')]
        [InlineData('ф')]
        [InlineData('\\')]
        [InlineData(' ')]
        [InlineData('"')]
        [InlineData('-')]
        public void ProcessChar_InvalidCharacter_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandNameCommandParserState(mock.Object, 'a');

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('0')]
        [InlineData('ф')]
        [InlineData('\\')]
        public void ProcessChar_InvalidLastCharacter_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandNameCommandParserState(mock.Object, 'a');
            state.ProcessChar('a');
            state.ProcessChar('b');

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_LastWhitespace_CreatesCommandAndTransitionsToAnyCharState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandNameCommandParserState(mock.Object, 'a');
            state.ProcessChar('a');
            state.ProcessChar('b');

            bool isValid = state.ProcessChar('_');

            Assert.True(isValid);
            mock.Verify(x => x.CreateCommand("aab"));
            mock.Verify(x => x.SetState(It.IsAny<AnyCharCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_NoCharacters_ReturnsTrueAndCreatesCommandAndTransitionsToFinishedState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandNameCommandParserState(mock.Object, 'a');

            bool isValid = state.FinishProcessing();

            Assert.True(isValid);
            mock.Verify(x => x.CreateCommand("a"));
            mock.Verify(x => x.SetState(It.IsAny<FinishedCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_AnyCharacters_ReturnsTrueAndCreatesCommandAndTransitionsToFinishedState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new CommandNameCommandParserState(mock.Object, 'a');
            state.ProcessChar('a');
            state.ProcessChar('b');

            bool isValid = state.FinishProcessing();

            Assert.True(isValid);
            mock.Verify(x => x.CreateCommand("aab"));
            mock.Verify(x => x.SetState(It.IsAny<FinishedCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
