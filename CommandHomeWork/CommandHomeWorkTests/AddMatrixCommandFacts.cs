using CommandHomeWork;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandHomeWorkTests
{
    public class AddMatrixCommandFacts
    {
        [Fact]
        public void Command_HorizontalRectangleMatrices_Correct()
        {
            int[][] matrix1 = new int[][]
                {
                    new int[] { 1, 1, 1},
                    new int[] { 2, 2, 2}
                };

            int[][] matrix2 = new int[][]
                {
                    new int[] { 3, 3, 3},
                    new int[] { 4, 4, 4}
                };

            var command = new AddMatrixCommand(2, 3, matrix1, matrix2);

            command.Execute();
            var result = command.GetResult();

            Assert.Equal(2, result.Length);
            Assert.Equal("4 4 4", result[0]);
            Assert.Equal("6 6 6", result[1]);
        }

        [Fact]
        public void Command_VerticalRectangleMatrices_Correct()
        {
            int[][] matrix1 = new int[][]
                {
                    new int[] { 1, 1},
                    new int[] { 2, 2},
                    new int[] { 3, 3},
                };

            int[][] matrix2 = new int[][]
                {
                    new int[] { 4, 4},
                    new int[] { 5, 5},
                    new int[] { 6, 6}
                };

            var command = new AddMatrixCommand(3, 2, matrix1, matrix2);

            command.Execute();
            var result = command.GetResult();

            Assert.Equal(3, result.Length);
            Assert.Equal("5 5", result[0]);
            Assert.Equal("7 7", result[1]);
            Assert.Equal("9 9", result[2]);
        }

        [Fact]
        public void Command_SingleElementMatrices_Correct()
        {
            int[][] matrix1 = new int[][]
                {
                    new int[] { 1 }
                };

            int[][] matrix2 = new int[][]
                {
                    new int[] { 2 }
                };

            var command = new AddMatrixCommand(1, 1, matrix1, matrix2);

            command.Execute();
            var result = command.GetResult();

            Assert.Single(result);
            Assert.Equal("3", result[0]);
        }
    }
}
