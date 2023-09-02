namespace WebApi.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Разбить перечисление на мелкие, указанной длины
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">Перечисление</param>
        /// <param name="batchSize">Длина будущего перечисления</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> enumerable, int batchSize)
        {
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {                
                yield return TakeBatch(enumerator, batchSize).ToArray();
            }
        }

        private static IEnumerable<T> TakeBatch<T>(IEnumerator<T> enumerator, int batchSize)
        {
            int n = 1;
            do
            {
                yield return enumerator.Current;                
            }
            while ((n++ < batchSize) && enumerator.MoveNext());
        }
    }
}
