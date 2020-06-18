using System;
using System.IO;
using System.Threading;

namespace FibonacciIterators
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Необходимо указать начальный и конечный элемент коллекции, а также путь к файлу, в который записывать результат");
                return;
            }

            int start = int.Parse(args[0]);
            int end = int.Parse(args[1]);

            IFibonacciSequenceIteratorFactory factory;
            if (start < 10 && end < 10)
            {
                factory = new RecursiveFibonacciSequenceIteratorFactory();
            }
            else
            {
                factory = new BinetFibonacciSequenceIteratorFactory();
            }

            var iterator = start <= end
                ? (IFibonacciSequenceIterator)factory.GetForwardFibonacciSequenceIterator(start, end)
                : factory.GetBackwardFibonacciSequenceIterator(start, end);

            using (var writer = new StreamWriter(args[2]))
            {
                while (iterator.HasMore())
                {
                    writer.WriteLine(iterator.GetNext());   
                }
            }
        }
    }
}
