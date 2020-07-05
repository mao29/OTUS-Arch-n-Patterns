using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MatrixAddAdapter
{
    public class MatrixAddUtilityAdapter : IMatrixAddAdapter
    {
        /// <summary>
        /// Путь к утилите сложения матриц.
        /// </summary>
        private string _addUtilityPath;

        /// <summary>
        /// Создать адаптер для сложения матриц.
        /// </summary>
        /// <param name="addUtilityPath">Путь к утилите сложения матриц.</param>
        public MatrixAddUtilityAdapter(string addUtilityPath)
        {
            if (!File.Exists(addUtilityPath))
            {
                throw new ArgumentException($"Не найден исполняемый файл утилиты сложения матриц по пути {addUtilityPath}", nameof(addUtilityPath));
            }

            _addUtilityPath = addUtilityPath;
        }

        /// <inheritdoc/>
        public void AddMatrixes(string sourceFile, string destinationFile)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = "dotnet.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.Arguments = $"\"{_addUtilityPath}\" \"{sourceFile}\" \"{destinationFile}\"";

                process.Start();
            }
        }
    }
}
