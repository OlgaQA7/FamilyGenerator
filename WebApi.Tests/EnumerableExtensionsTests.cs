using WebApi.Extensions;

namespace WebApi.Tests
{
    public class EnumerableExtensionsTests
    {
        [Test]
        public void Batch_ReturnValidResult()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6, 7 };

            var validBatchArray = new int[][] { 
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7 }
            };

            var batch = array.Batch(3);

            var batchArray = batch.Select(x => x.ToArray()).ToArray();

            Assert.That(batchArray, Is.EqualTo(validBatchArray));
        }
    }
}
