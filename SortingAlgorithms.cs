using System.Collections.Specialized;

namespace Lab3
{
    static class SortingAlgorithms
    {
        public static double[] BubbleSort(this double[] array)
        {
            // переменные для статистики
            int C = 0, M = 0;

            double[] _array = (double[])array.Clone(); // копия массива, чтобы не изменять передаваемый

            int n = _array.Length;

            // внешний цикл проходит по всему массиву
            for (int i = 0; i < n - 1; i++)
            {
                // внутренний цикл сравнивает соседние элементы
                for (int j = 0; j < n - i - 1; j++)
                {
                    // если текущий элемент больше следующего, меняем их местами
                    if (_array[j] > _array[j + 1])
                    {
                        (_array[j + 1], _array[j]) = (_array[j], _array[j + 1]);
                        M++;
                    }

                    C++;
                }
            }

            Console.WriteLine($"Сортировка Пузырькем. C/N = {C / (double)n}; M/N = {M / (double)n}"); 

            return _array;
        }

        public static double[] SelectionSort(this double[] array)
        {
            int C = 0, M = 0;

            double[] _array = (double[])array.Clone();

            int n = _array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // находим индекс минимального элемента в неотсортированной части массива
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (_array[j] < _array[minIndex])
                    {
                        minIndex = j; // обновляем индекс минимального элемента
                    }

                    C++;
                }

                // обмениваем найденный минимальный элемент с первым элементом неотсортированной части
                if (minIndex != i)
                {
                    (_array[minIndex], _array[i]) = (_array[i], _array[minIndex]);

                    M++;
                }
            }

            Console.WriteLine($"Сортировка Вставкой. C/N = {C / (double)n}; M/N = {M / (double)n}");

            return _array;
        }

        public static double[] MergeSort(this double[] array)
        {
            double[] _array = (double[])array.Clone();

            MergeSort(_array, 0, _array.Length - 1);

            return _array;
        }

        private static void MergeSort(double[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                // рекурсивно сортируем обе половины
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                // сливаем отсортированные половины
                Merge(array, left, middle, right);
            }
        }

        private static void Merge(double[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            double[] leftArray = new double[n1];
            double[] rightArray = new double[n2];

            // копируем данные в временные массивы
            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, middle + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            // сравниваем и сливаем обратно в исходный массив
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            // копируем оставшиеся элементы
            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }

        public static double[] QuickSort(this double[] array)
        {
            double[] _array = (double[])array.Clone();

            QuickSort(_array, 0, _array.Length - 1);

            return _array;
        }

        private static void QuickSort(double[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(double[] array, int left, int right)
        {
            double pivot = array[right]; // опорный элемент
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    // меняем местами
                    (array[j], array[i]) = (array[i], array[j]);
                }
            }

            // ставим опорный элемент на его место
            (array[right], array[i + 1]) = (array[i + 1], array[right]);
            return i + 1;
        }
    }
}
