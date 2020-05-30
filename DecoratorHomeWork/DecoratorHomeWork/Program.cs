using System;
using System.IO;

namespace DecoratorHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var parsedArgs = new Args(args);

                IDataTransformer someTransformer = new IdleDataTransformer();
                var sortingTransformer = CreateSortingDataTransformer(parsedArgs.SortingMethod, someTransformer);

                string[] data = File.ReadAllLines(parsedArgs.SourceFilePath);
                File.WriteAllLines(parsedArgs.DestinationFilePath, sortingTransformer.TransformData(data));                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static BaseSortingDataTransformer CreateSortingDataTransformer(SortingMethod sortingMethod, IDataTransformer innerTransformer)
        {
            switch (sortingMethod)
            {
                case SortingMethod.Bubble:
                    return new BubbleSortingDataTransformer(innerTransformer);
                case SortingMethod.Insertion:
                    return new InsertionSortingDataTransformer(innerTransformer);
                case SortingMethod.Selection:
                    return new SelectionSortingDataTransformer(innerTransformer);
            }

            throw new ArgumentOutOfRangeException(nameof(sortingMethod), "Не существует обработчика с указанным методом сортировки");
        }
    }
}
