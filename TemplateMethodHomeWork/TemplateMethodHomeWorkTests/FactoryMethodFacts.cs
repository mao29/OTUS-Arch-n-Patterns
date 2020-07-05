using System;
using System.Collections.Generic;
using System.Text;
using TemplateMethodHomeWork;
using Xunit;

namespace TemplateMethodHomeWorkTests
{
    /// <summary>
    /// Класс с тестами фабричного метода создания обработчика операции над матрицами.
    /// </summary>
    public class FactoryMethodFacts
    {
        [Fact]
        public void GetMatrixProcessor_Add_ReturnsAddMatrixProcessor()
        {
            var processor = Program.GetMatrixProcessor(MatrixOperation.Add, "1.txt", "2.txt");

            Assert.IsType<AddMatrixProcessor>(processor);
        }

        [Fact]
        public void GetMatrixProcessor_Determinant_ReturnsDeterminantMatrixProcessor()
        {
            var processor = Program.GetMatrixProcessor(MatrixOperation.Determinant, "1.txt", "2.txt");

            Assert.IsType<DeterminantMatrixProcessor>(processor);
        }
        
        [Fact]
        public void GetMatrixProcessor_Transponate_ReturnsTransponateMatrixProcessor()
        {
            var processor = Program.GetMatrixProcessor(MatrixOperation.Transponate, "1.txt", "2.txt");

            Assert.IsType<TransponateMatrixProcessor>(processor);
        }
    }
}
