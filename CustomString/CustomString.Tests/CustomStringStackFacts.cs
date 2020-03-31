using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CustomString.Tests
{
    public class CustomStringStackFacts
    {
        [Fact]
        public void Constructor_NegativeCapacity_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>("capacity", () => new CustomStringStack(-2));
        }

        [Theory]
        [InlineData(2, "abc", "def", "ghj")]
        [InlineData(3, "s1", "s2", "s3", "s4", "s5", "s6", "s7")]
        public void Push_OverInitialCapacity_WorksCorrectly(int initialCapacity, params string[] strings)
        {
            ICustomString[] customStrings = strings.Select(s => new CustomString(s.ToCharArray())).Cast<ICustomString>().ToArray();

            var stack = new CustomStringStack(initialCapacity);

            foreach (var customString in customStrings)
            {
                stack.Push(customString);
            }

            var actualElements = new ICustomString[customStrings.Length];
            int currentIndex = 0;
            while (!stack.IsEmpty())
            {
                actualElements[currentIndex] = stack.Pop();
                currentIndex++;
            }

            var expectedElements = customStrings;
            Array.Reverse(expectedElements);

            Assert.Equal(expectedElements, actualElements);
        }

        [Fact]
        public void Push_OverMaximumCapacity_ThrowsStackOverflowException()
        {
            var stack = new CustomStringStack(1, new NoResizeArrayResizerStub<ICustomString>());
            stack.Push(new CustomString());

            Assert.Throws<StackOverflowException>(() => stack.Push(new CustomString()));
        }

        [Fact]
        public void IsEmpty_NewStack_True()
        {
            var stack = new CustomStringStack();
            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_EmptyStack_True()
        {
            var stack = new CustomStringStack();
            stack.Push(new CustomString());
            stack.Pop();
            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_NotEmptyStack_False()
        {
            var stack = new CustomStringStack();
            stack.Push(new CustomString());
            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void Peek_NewStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStringStack();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStringStack();

            stack.Push(new CustomString());
            stack.Pop();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Peek_StackContentDoesntChange()
        {
            var str = new CustomString();
            var stack = new CustomStringStack();

            stack.Push(str);
            var peekStr = stack.Peek();

            Assert.Equal(str, peekStr);
            Assert.False(stack.IsEmpty());

            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Pop_NewStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStringStack();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStringStack();

            stack.Push(new CustomString());
            stack.Pop();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void PopAll_NewStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStringStack();

            Assert.Throws<InvalidOperationException>(() => stack.PopAll());
        }

        [Fact]
        public void PopAll_EmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStringStack();

            stack.Push(new CustomString());
            stack.Pop();

            Assert.Throws<InvalidOperationException>(() => stack.PopAll());
        }

        [Fact]
        public void PopAll_NonEmptyStack_BecomesEmpty()
        {
            var str1 = new CustomString();
            var str2 = new CustomString();
            var str3 = new CustomString();
            var stack = new CustomStringStack();

            stack.Push(str1);
            stack.Push(str2);
            stack.Push(str3);

            var result = stack.PopAll();

            Assert.True(stack.IsEmpty());
            Assert.Equal(str3, result[0]);
            Assert.Equal(str2, result[1]);
            Assert.Equal(str1, result[2]);
        }

        [Theory]
        [InlineData("s1", "s2")]
        [InlineData("s1", "s2", "str3")]
        [InlineData("s1", "s2", "str3", "sss4")]
        public void LIFO(params string[] strings)
        {
            ICustomString[] customStrings = strings.Select(s => new CustomString(s.ToCharArray())).Cast<ICustomString>().ToArray();

            var stack = new CustomStringStack();

            foreach (var customString in customStrings)
            {
                stack.Push(customString);
            }

            var actualElements = new ICustomString[customStrings.Length];
            int currentIndex = 0;
            while (!stack.IsEmpty())
            {
                actualElements[currentIndex] = stack.Pop();
                currentIndex++;
            }

            var expectedElements = customStrings;
            Array.Reverse(expectedElements);

            Assert.Equal(expectedElements, actualElements);
        }

        [Fact]
        public void DifferentCustomStringImplementations_WorksCorrectly()
        {
            var customStrings = new ICustomString[]
            {
                new CustomString(),
                new SubstringableCustomStringDerived(),
                new SubstringableCustomStringComposed(),
                new CustomString()
            };

            var stack = new CustomStringStack();

            foreach (var customString in customStrings)
            {
                stack.Push(customString);
            }

            var actualElements = new ICustomString[customStrings.Length];
            int currentIndex = 0;
            while (!stack.IsEmpty())
            {
                actualElements[currentIndex] = stack.Pop();
                currentIndex++;
            }

            var expectedElements = customStrings;
            Array.Reverse(expectedElements);

            Assert.Equal(expectedElements, actualElements);
        }
    }
}
