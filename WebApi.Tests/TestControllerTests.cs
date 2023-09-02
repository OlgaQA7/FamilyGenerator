using Moq;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class TestControllerTests
    {
        [Test]
        public void Sort_ValidOrder()
        {
            var sortData = new[] { "Коля", "Петя", "Вася", "Дуся" };
            var sortedData = new[] { "Вася", "Дуся", "Коля", "Петя" };

            var controllerMock = new Mock<TestController>();
            
            var controller = controllerMock.Object;
            var result = controller.Sort(sortData);
            
            Assert.That(result, Is.EqualTo(sortedData));
        }
    }
}
