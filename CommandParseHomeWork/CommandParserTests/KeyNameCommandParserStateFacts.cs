using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class KeyNameCommandParserStateFacts
    {
        [Theory]
        [InlineData('_')]
        [InlineData('B')]
        [InlineData('0')]
        [InlineData('x')]
        [InlineData(' ')]
        public void ProcessChar_InvalidCharacter_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyNameCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('a')]
        [InlineData('r')]
        [InlineData('p')]
        public void ProcessChar_RequiredParameterKeys_TransitionsToWhitespaceAfterParameterizedKeyState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyNameCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.Is<WhitespaceAfterParameterizedKeyCommandParserState>(x => x.KeyName == character.ToString())));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('c')]
        public void ProcessChar_NoParameterKey_TransitionsToWhitespaceState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyNameCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandKey(It.Is<CommandKey>(x => x.Name == character.ToString())));
            mock.Verify(x => x.SetState(It.IsAny<WhitespaceCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('n')]
        [InlineData('l')]
        [InlineData('s')]
        public void ProcessChar_PossibleParameterKey_TransitionsToWhitespaceState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyNameCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.Is<WhitespaceAfterKeyCommandParserState>(x => x.KeyName == character.ToString())));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_ReturnsFalseAndTransitionsToInvalidState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyNameCommandParserState(mock.Object);

            bool isValid = state.FinishProcessing();

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
