using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class FirstCommandNameCharacterCommandParserStateFacts
    {
        [Theory]
        [InlineData('a')]
        [InlineData('B')]
        public void ProcessChar_ValidCharacter_ReturnsTrueAndTransitionsToCommandNameState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new FirstCommandNameCharacterCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.True(isValid);
            mock.Verify(x => x.SetState(It.IsAny<CommandNameCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData('0')]
        [InlineData('ф')]
        [InlineData('\\')]
        [InlineData(' ')]
        [InlineData('_')]
        [InlineData('"')]
        [InlineData('-')]
        public void ProcessChar_InvalidCharacter_ReturnsFalseAndTransitionsToInvalidState(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new FirstCommandNameCharacterCommandParserState(mock.Object);

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
