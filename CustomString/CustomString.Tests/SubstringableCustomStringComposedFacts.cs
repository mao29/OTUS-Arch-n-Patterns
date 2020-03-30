using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString.Tests
{
    /// <summary>
    /// Класс с тестами <see cref="SubstringableCustomStringComposed"/>.
    /// </summary>
    public class SubstringableCustomStringComposedFacts : ISubstringableCustomStringFacts
    {
        protected override ICustomString GetCustomString()
        {
            return GetSubstringableCustomString();
        }

        protected override ICustomString GetCustomString(char character)
        {
            return GetSubstringableCustomString(character);
        }

        protected override ICustomString GetCustomString(char[] characters)
        {
            return GetSubstringableCustomString(characters);
        }

        protected override ISubstringableCustomString GetSubstringableCustomString()
        {
            return new SubstringableCustomStringComposed();
        }

        protected override ISubstringableCustomString GetSubstringableCustomString(char character)
        {
            return new SubstringableCustomStringComposed(character);
        }

        protected override ISubstringableCustomString GetSubstringableCustomString(char[] characters)
        {
            return new SubstringableCustomStringComposed(characters);
        }
    }
}
