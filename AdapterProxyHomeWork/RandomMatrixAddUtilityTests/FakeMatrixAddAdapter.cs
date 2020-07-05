using MatrixAddAdapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMatrixAddUtilityTests
{
    /// <summary>
    /// Фейковый адаптер сложения матриц.
    /// </summary>
    class FakeMatrixAddAdapter : IMatrixAddAdapter
    {
        /// <inheritdoc/>
        public void AddMatrixes(string sourceFile, string destinationFile)
        {            
        }
    }
}
