using CommandParser;
using Moq;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class KeyParameterCommandParserStateFacts
    {
        [Theory]
        [InlineData('a')]
        [InlineData('B')]
        [InlineData('2')]
        public void ProcessChar_ValidCharacter_ReturnsTrue(char character)
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyParameterCommandParserState(mock.Object, "a", 'p');

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

            var state = new KeyParameterCommandParserState(mock.Object, "a", 'p');

            bool isValid = state.ProcessChar(character);

            Assert.False(isValid);
            mock.Verify(x => x.SetState(It.IsAny<InvalidCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_FirstWhitespace_AddsParameterizedKeyAndTransitionsToAnyCharState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyParameterCommandParserState(mock.Object, "a", 'p');

            bool isValid = state.ProcessChar('_');

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandKey(It.Is<ParameterizedCommandKey>(x => x.Name == "a" && x.Parameter == "p")));
            mock.Verify(x => x.SetState(It.IsAny<AnyCharCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ProcessChar_LastWhitespace_AddsParameterizedKeyAndTransitionsToAnyCharState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyParameterCommandParserState(mock.Object, "a", 'p');
            state.ProcessChar('a');
            state.ProcessChar('r');
            state.ProcessChar('a');
            state.ProcessChar('m');

            bool isValid = state.ProcessChar('_');

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandKey(It.Is<ParameterizedCommandKey>(x => x.Name == "a" && x.Parameter == "param")));
            mock.Verify(x => x.SetState(It.IsAny<AnyCharCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_NoCharacters_ReturnsTrueAndAddsParameterizedKeyAndTransitionsToFinishedState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyParameterCommandParserState(mock.Object, "a", 'p');

            bool isValid = state.FinishProcessing();

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandKey(It.Is<ParameterizedCommandKey>(x => x.Name == "a" && x.Parameter == "p")));
            mock.Verify(x => x.SetState(It.IsAny<FinishedCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }

        [Fact]
        public void FinishProcessing_AnyCharacters_ReturnsTrueAndAddsParameterAndTransitionsToFinishedState()
        {
            var mock = new Mock<IStatefulCommandParser>();

            var state = new KeyParameterCommandParserState(mock.Object, "a", 'p');
            state.ProcessChar('b');

            bool isValid = state.FinishProcessing();

            Assert.True(isValid);
            mock.Verify(x => x.AddCommandKey(It.Is<ParameterizedCommandKey>(x => x.Name == "a" && x.Parameter == "pb")));
            mock.Verify(x => x.SetState(It.IsAny<FinishedCommandParserState>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
