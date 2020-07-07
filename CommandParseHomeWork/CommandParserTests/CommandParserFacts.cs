using CommandParser;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandParserTests
{
    public class CommandParserFacts
    {
        [Theory]
        [InlineData("aBc", "Команда: aBc\r\n")]
        [InlineData("abc_1", "Команда: abc\r\nПараметры:\r\n1\r\n")]
        [InlineData("abc_aBc1", "Команда: abc\r\nПараметры:\r\naBc1\r\n")]
        [InlineData("abc_aBc1_-c", "Команда: abc\r\nКлючи:\r\nc\r\nПараметры:\r\naBc1\r\n")]        
        [InlineData("abc_-c_aBc1", "Команда: abc\r\nКлючи:\r\nc\r\nПараметры:\r\naBc1\r\n")]
        [InlineData("abc_-c", "Команда: abc\r\nКлючи:\r\nc\r\n")]
        [InlineData("abc_-m", "Команда: abc\r\nКлючи:\r\nm\r\n")]
        [InlineData("abc_-c_-a_aParam", "Команда: abc\r\nКлючи:\r\nc\r\na, параметр: aParam\r\n")]
        [InlineData("abc_-c_\"quotedParam\"_-a_aParam_-m_\"quotedKeyParam\"___param", "Команда: abc\r\n" +
            "Ключи:\r\nc\r\na, параметр: aParam\r\nm, параметр: quotedKeyParam\r\n" +
            "Параметры:\r\nquotedParam\r\nparam\r\n")]
        public void TryParseCommand_ValidCommand_Parsed(string commandStr, string commandText)
        {
            var parser = new CommandParser.CommandParser();
            bool isValid = parser.TryParseCommand(commandStr, out var command);

            Assert.True(isValid);
            Assert.Equal(commandText, command.ToString());
        }

        [Theory]
        [InlineData("")]
        [InlineData("_____")]
        [InlineData("a1")]
        [InlineData("ффф")]
        [InlineData("abc-c")]
        [InlineData("abc\"param\"")]
        [InlineData("abc_\"param-")]
        [InlineData("abc_\"param")]
        [InlineData("abc_param-c")]
        [InlineData("abc_param_-a___")]
        [InlineData("abc_param_-a_-c")]
        [InlineData("abc_param_-a_\"par-")]
        [InlineData("abc_param_-a_\"par")]
        [InlineData("abc_param_-1")]
        [InlineData("abc_param_-")]
        public void TryParseCommand_InvalidCommand_Invalid(string commandStr)
        {
            var parser = new CommandParser.CommandParser();
            bool isValid = parser.TryParseCommand(commandStr, out var _);

            Assert.False(isValid);
        }
    }
}
