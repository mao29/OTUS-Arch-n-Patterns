using System;
using System.IO;

namespace FactoryHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var parsedArgs = new Args(args);

                string[] data = File.ReadAllLines(parsedArgs.SourceFilePath);

                var sortedDataWriter = new SeparatedSortedDataWriterFactory().GetSortedDataWriter(parsedArgs.Separator);

                using (var writer = new StreamWriter(parsedArgs.DestinationFilePath))
                {
                    switch (parsedArgs.SortingMethod)
                    {
                        case SortingMethod.Bubble:
                            sortedDataWriter.WriteBubbleSortedData(data, writer);
                            break;
                        case SortingMethod.Selection:
                            sortedDataWriter.WriteSelectionSortedData(data, writer);
                            break;
                        case SortingMethod.Insertion:
                            sortedDataWriter.WriteInsertionSortedData(data, writer);
                            break;
                        default:
                            throw new ArgumentException("Не существует класса, сортирующего заданным способом.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
