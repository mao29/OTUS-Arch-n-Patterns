using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class QuotedKeyParameterCommandParserStateFacts
    {
        [Theory]
        [InlineData('a')]
        [InlineData('B')]
        [InlineData('2')]
        [InlineData('_')]
        public void ProcessChar_ValidCharacter_ReturnsTrue(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedKeyParameterCommandParserState(mock.Object, "a", 'p');

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

            var state = new QuotedKeyParameterCommandParserState(mock.Object, "a", 'p');

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_Quote_AddsParameterAndTransitionsToAnyCharState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedKeyParameterCommandParserState(mock.Object, "a", 'p');
            state.ProcessChar('a');
            state.ProcessChar('r');

            bool isValid = state.ProcessChar('"');

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandKey(It.Is<ParameterizedCommandKey>(x => x.Name == "a" && x.Parameter == "par")));
            mock.Verify(x => x.SetState(It.IsAny<WhitespaceCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_FirstQuote_AddsParameterAndTransitionsToAnyCharState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedKeyParameterCommandParserState(mock.Object, "a", 'p');

            bool isValid = state.ProcessChar('"');

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandKey(It.Is<ParameterizedCommandKey>(x => x.Name == "a" && x.Parameter == "p")));
            mock.Verify(x => x.SetState(It.IsAny<WhitespaceCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_ReturnsFalseAndTransitionsToInvalidState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new QuotedKeyParameterCommandParserState(mock.Object, "a", 'p');

            bool isValid = state.FinishProcessing();

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
