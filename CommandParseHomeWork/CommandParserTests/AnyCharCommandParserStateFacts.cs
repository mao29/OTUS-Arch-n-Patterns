using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class AnyCharCommandParserStateFacts
    {
        [Fact]
        public void ProcessChar_Whitespace_Allowed()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharCommandParserState(mock.Object);

            bool isValid = state.ProcessChar('_');

            Assert.True(isValid);
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_Dash_AddsKeyAndTransitionsToKeyNameState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharCommandParserState(mock.Object);

            bool isValid = state.ProcessChar('-');

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.IsAny<KeyNameCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_Quote_TransitionsToQuotedCommandParameterState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharCommandParserState(mock.Object);

            bool isValid = state.ProcessChar('"');

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.IsAny<QuotedCommandParameterFirstCharCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('a')]
        [InlineData('B')]
        [InlineData('1')]
        public void ProcessChar_ValidParameterNameCharacter_TransitionsToCommandParameterState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.IsAny<CommandParameterCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('ф')]
        [InlineData('\\')]
        [InlineData(' ')]
        public void ProcessChar_InvalidCharacter_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_ReturnsTrueAndTransitionsToFinishedState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharCommandParserState(mock.Object);

            bool isValid = state.FinishProcessing();

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.IsAny<FinishedCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
