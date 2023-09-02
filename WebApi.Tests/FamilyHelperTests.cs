using Moq;
using WebApi.Contracts;
using WebApi.Helpers;
using WebApi.Helpers.Interfaces;

namespace WebApi.Tests
{
    internal class FamilyHelperTests
    {
        [Test]
        public void GetFamily_ValidateChild() 
        {
            int n = 2;
            var validChild = new Family()
            {
                Husband = "Тепляков Максим Дмитриевич",
                Wife = "Теплякова Светлана Михайловна"
            };

            var validFamily = new Family()
            {
                Husband = "Тепляков Дмитрий Николаевич",
                Wife = "Левченко Ольга Геннадьевна",
                Gender = "Сын",
                Generation = 1,
                NextGeneration = new Family[] { validChild, validChild }
            };


            var childGeneratorMock = new Mock<IChildGenerator>();
            childGeneratorMock
                .Setup(x => x.CalculateChild("Дмитрий", "Тепляков", 1))
                .Returns(validChild);

            var f = new FamilyHelper(childGeneratorMock.Object);
            var result = f.GetFamily(n);
            
            Assert.That(validFamily.Husband, Is.EqualTo(result.Family.Husband));
            Assert.That(validFamily.Wife, Is.EqualTo(result.Family.Wife));
            Assert.That(validFamily.Generation, Is.EqualTo(result.Family.Generation));
            Assert.That(validFamily.Gender, Is.EqualTo(result.Family.Gender));
            Assert.That(validChild, Is.EqualTo(result.Family.NextGeneration[0]));
            Assert.That(validChild, Is.EqualTo(result.Family.NextGeneration[1]));
        }
    }
}
