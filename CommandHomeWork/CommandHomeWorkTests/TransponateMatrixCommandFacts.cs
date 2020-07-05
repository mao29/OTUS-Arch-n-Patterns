using CommandHomeWork;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandHomeWorkTests
{
    public class TransponateMatrixCommandFacts
    {
        [Fact]
        public void Command_HorizontalRectangleMatrices_Correct()
        {
            int[][] matrix = new int[][]
                {
                    new int[] { 1, 2, 3},
                    new int[] { 4, 5, 6}
                };


            var command = new TransponateMatrixCommand(2, 3, matrix);

            command.Execute();
            var result = command.GetResult();

            Assert.Equal(3, result.Length);
            Assert.Equal("1 4", result[0]);
            Assert.Equal("2 5", result[1]);
            Assert.Equal("3 6", result[2]);
        }

        [Fact]
        public void Command_VerticalRectangleMatrices_Correct()
        {
            int[][] matrix = new int[][]
                {
                    new int[] { 1, 2},
                    new int[] { 3, 4},
                    new int[] { 5, 6},
                };

          
            var command = new TransponateMatrixCommand(3, 2, matrix);

            command.Execute();
            var result = command.GetResult();

            Assert.Equal(2, result.Length);
            Assert.Equal("1 3 5", result[0]);
            Assert.Equal("2 4 6", result[1]);            
        }

        [Fact]
        public void Command_SingleElementMatrices_Correct()
        {
            int[][] matrix = new int[][]
                {
                    new int[] { 1 }
                };
     
            var command = new TransponateMatrixCommand(1, 1, matrix);

            command.Execute();
            var result = command.GetResult();

            Assert.Single(result);
            Assert.Equal("1", result[0]);
        }
    }
}
