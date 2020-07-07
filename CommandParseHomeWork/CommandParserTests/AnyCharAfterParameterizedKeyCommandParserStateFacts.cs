using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class AnyCharAfterParameterizedKeyCommandParserStateFacts
    {
        [Fact]
        public void ProcessChar_Whitespace_ReturnsTrue()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharAfterParameterizedKeyCommandParserState(mock.Object, "a");

            bool isValid = state.ProcessChar('_');

            Assert.True(isValid);            
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_Quote_ReturnsTrueAndTransitionsToQuotedKeyParameterState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharAfterParameterizedKeyCommandParserState(mock.Object, "a");

            bool isValid = state.ProcessChar('"');

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.Is<QuotedKeyParameterFirstCharCommandParserState>(x => x.KeyName == "a")));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('a')]
        [InlineData('B')]
        [InlineData('1')]
        public void ProcessChar_ValidParameterCharacter_ReturnsTrueAndTransitionsToKeyParameterState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharAfterParameterizedKeyCommandParserState(mock.Object, "a");

            bool isValid = state.ProcessChar(character);

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.Is<KeyParameterCommandParserState>(x => x.KeyName == "a")));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('ф')]
        [InlineData('-')]
        [InlineData('\\')]
        [InlineData(' ')]
        public void ProcessChar_InvalidCharacter_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharAfterParameterizedKeyCommandParserState(mock.Object, "a");

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_ReturnsFalseAndTransitionsToInvalidState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new AnyCharAfterParameterizedKeyCommandParserState(mock.Object, "a");

            bool isValid = state.FinishProcessing();

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
