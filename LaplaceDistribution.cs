namespace Lab3
{
    internal static class LaplaceDistribution
    {
        private static readonly Random rand = new();

        public static double Generate(double mu, double b)
        {
            // генерируем случайное число U из диапазона [-0.5, 0.5]
            double U = rand.NextDouble() - 0.5;

            // метод обратного преобразования для генерации числа с распределением Лапласа
            return mu - b * Math.Sign(U) * Math.Log(1 - 2 * Math.Abs(U));
        }

        public static double[] GenerateArray(int N, double mu, double b)
        {
            double[] result = new double[N];

            for (int i = 0; i < N; i++)
            {
                result[i] = Generate(mu, b);
            }

            return result;
        }
    }
}
