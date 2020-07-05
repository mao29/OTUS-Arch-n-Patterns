using CommandHomeWork;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandHomeWorkTests
{
    public class CalculateDeterminantCommandFacts
    {
        [Fact]
        public void Command_SingleElemetMatrix_Correct()
        {
            int[][] matrix = new int[][]
              {
                    new int[] { 10 }
              };

            var command = new CalculateDeterminantCommand(matrix);

            command.Execute();
            var result = command.GetResult();

            Assert.Single(result);
            Assert.Equal("10", result[0]);
        }

        [Fact]
        public void Command_2x2Matrix_Correct()
        {
            int[][] matrix = new int[][]
              {
                    new int[] { 1, 2 },
                    new int[] { 3, 4 }
              };

            var command = new CalculateDeterminantCommand(matrix);

            command.Execute();
            var result = command.GetResult();

            Assert.Single(result);
            Assert.Equal("-2", result[0]);
        }

        [Fact]
        public void Command_3x3Matrix_Correct()
        {
            int[][] matrix = new int[][]
              {
                    new int[] { 2, 4, 3 },
                    new int[] { 5, 7, 8 },
                    new int[] { 6, 9, 1 }
              };

            var command = new CalculateDeterminantCommand(matrix);

            command.Execute();
            var result = command.GetResult();

            Assert.Single(result);
            Assert.Equal("51", result[0]);
        }
    }
}
