using System.Diagnostics;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new();

            long algorithmOneTime, algorithmTwoTime, algorithmThreeTime, algorithmFourTime;
            int N = 4000, mu = 5, b = 5;

            // генерируем по распределению Лапласа
            double[] numberArray = LaplaceDistribution.GenerateArray(N, mu, b);
            Console.WriteLine("Первые 100 чисел сгенерированного массива:");
            Console.WriteLine(ArrayToString(numberArray[..100])); 
            Console.ReadKey();
                        
            // алгоритм пузырька
            Console.Clear();
            stopwatch.Start();
            double[] bubbleArray = numberArray.BubbleSort(); // сортируем пузырькем
            stopwatch.Stop();
            algorithmOneTime = stopwatch.ElapsedMilliseconds; // записываем потраченное время
            Console.WriteLine("Первые 100 чисел массива, отсортированного Методом Пузырька (простой метод):");
            Console.WriteLine(ArrayToString(bubbleArray[..100]));
            Console.ReadKey();

            // алгоритм выбора
            Console.Clear();
            stopwatch.Restart();
            double[] selectionArray = numberArray.SelectionSort();
            stopwatch.Stop();
            algorithmTwoTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Первые 100 чисел массива, отсортированного Методом Выбора (простой метод):");
            Console.WriteLine(ArrayToString(selectionArray[..100]));
            Console.ReadKey();

            // алгоритм слияния
            Console.Clear();
            stopwatch.Restart();
            double[] mergeArray = numberArray.MergeSort();
            stopwatch.Stop();
            algorithmThreeTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Первые 100 чисел массива, отсортированного Методом Слияния (сложный метод):");
            Console.WriteLine(ArrayToString(mergeArray[..100]));
            Console.ReadKey();

            // алгоритм быстрой сортировки
            Console.Clear();
            stopwatch.Restart();
            double[] quickArray = numberArray.QuickSort();
            stopwatch.Stop();
            algorithmFourTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Первые 100 чисел массива, отсортированного Методом Быстрой Сортировки (сложный метод):");
            Console.WriteLine(ArrayToString(mergeArray[..100]));
            Console.ReadKey();

            // вывод статистики
            double averageSimpleAlgTime = (algorithmOneTime + algorithmTwoTime) / 2.0;
            double averageHardAlgTime = (algorithmThreeTime + algorithmFourTime) / 2.0;
            double relativeAlgorithmOneTime = algorithmOneTime / averageHardAlgTime;
            double relativeAlgorithmTwoTime = algorithmTwoTime / averageHardAlgTime;
            double relativeAlgorithmThreeTime = algorithmThreeTime / averageSimpleAlgTime;
            double relativeAlgorithmFourTime = algorithmFourTime / averageSimpleAlgTime;
            Console.Clear();
            Console.WriteLine($"{"Тип сортировки", -30}{"Затраченное время (мс)", -25}{"Относительное время сортировки", -30}");
            Console.WriteLine($"{"Сортировка Пузырькем", -30}{algorithmOneTime, -25}{relativeAlgorithmOneTime, -30}");
            Console.WriteLine($"{"Сортировка Выбором", -30}{algorithmTwoTime, -25}{relativeAlgorithmTwoTime,-30}");
            Console.WriteLine($"{"Сортировка Слиянием",-30}{algorithmThreeTime,-25}{relativeAlgorithmThreeTime,-30}");
            Console.WriteLine($"{"Быстрая Сортировка",-30}{algorithmFourTime,-25}{relativeAlgorithmFourTime,-30}");
        }

        static string ArrayToString(double[] numberArray)
        {
            return string.Join("\n", numberArray);
        }
    }
}
