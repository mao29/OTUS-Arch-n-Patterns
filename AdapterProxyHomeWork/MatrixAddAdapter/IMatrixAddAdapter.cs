using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAddAdapter
{
    /// <summary>
    /// Интерфейс адаптера для сложения матриц из исходного файла и печати результата в целевой файл.
    /// </summary>
    public interface IMatrixAddAdapter
    {
        /// <summary>
        /// Сложить матрицы в исходном файле и вывести результат в целевой файл.
        /// </summary>
        /// <param name="sourceFile">Путь к файлу с исходными данными.</param>
        /// <param name="destinationFile">Путь к файлу для вывода результата.</param>
        void AddMatrixes(string sourceFile, string destinationFile);
    }
}
