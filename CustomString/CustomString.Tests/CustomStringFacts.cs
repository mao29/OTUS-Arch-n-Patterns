using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString.Tests
{
    /// <summary>
    /// Класс с тестами <see cref="CustomString"/>.
    /// </summary>
    public class CustomStringFacts : ICustomStringFacts
    {
        protected override ICustomString GetCustomString()
        {
            return new CustomString();
        }

        protected override ICustomString GetCustomString(char character)
        {
            return new CustomString(character);
        }

        protected override ICustomString GetCustomString(char[] characters)
        {
            return new CustomString(characters);
        }
    }
}
