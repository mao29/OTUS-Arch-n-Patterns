using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString.Tests
{
    /// <summary>
    /// Класс с тестами <see cref="SubstringableCustomStringDerived"/>.
    /// </summary>
    public class SubstringableCustomStringDerivedFacts : ISubstringableCustomStringFacts
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
            return new SubstringableCustomStringDerived();
        }

        protected override ISubstringableCustomString GetSubstringableCustomString(char character)
        {
            return new SubstringableCustomStringDerived(character);
        }

        protected override ISubstringableCustomString GetSubstringableCustomString(char[] characters)
        {
            return new SubstringableCustomStringDerived(characters);
        }
    }
}
