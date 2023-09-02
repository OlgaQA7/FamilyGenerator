using Moq;
using WebApi.Contracts;
using WebApi.Helpers;
using WebApi.Helpers.Interfaces;
using static WebApi.Data.DictionaryNames;

namespace WebApi.Tests
{
    internal class ChildGeneratorTests
    {
        [Test]
        public void ChildGenerator_ValidateBoy()
        {
            var validChildBoy = new Family()
            { 
                Husband = "Тепляков Максим Дмитриевич",
                Wife = "Теплякова Светлана Михайловна"
            };

            var nameHelper = new Mock<IRandomChildHelper>();
            nameHelper
                 .Setup(x => x.GetGenderRandom())
                 .Returns(true);

            nameHelper
                 .Setup(x => x.GetManLastName())
                 .Returns("Тепляков");

            nameHelper
                 .Setup(x => x.GetRandomManName())
                 .Returns("Максим");

            nameHelper
                 .Setup(x => x.GetRandomWomanName())
                 .Returns("Светлана");

            nameHelper
                 .Setup(x => x.GetWomanMiddleName())
                 .Returns("Михайловна");

            var generator = new ChildGenerator(nameHelper.Object);
            var childBoy = generator.CalculateChild("Дмитрий", "Тепляков", 1);


            Assert.That(validChildBoy.Husband, Is.EqualTo(childBoy.Husband));
            Assert.That(validChildBoy.Wife, Is.EqualTo(childBoy.Wife));
        }

        [Test]
        public void ChildGenerator_ValidateGirl()
        {
            var validChildGirl = new Family()
            {
                Husband = "Морозов Матвей Петрович",
                Wife = "Морозова София Дмитриевна",
            };

            var nameHelper = new Mock<IRandomChildHelper>();
            nameHelper
                .Setup(x => x.GetGenderRandom())
                .Returns(false);

            nameHelper
                .Setup(x => x.GetManLastName())
                .Returns("Морозов");

            nameHelper
                .Setup(x => x.GetRandomWomanName())
                .Returns("София");

            nameHelper
                .Setup(x => x.GetWomanMiddleName())
                .Returns("Дмитриевна");

            nameHelper
                .Setup(x => x.GetRandomManName())
                .Returns("Матвей");

            nameHelper
                .Setup(x => x.GetRandomManMiddleName())
                .Returns("Петрович");

            var generator = new ChildGenerator(nameHelper.Object);
            var childGirl = generator.CalculateChild("Дмитрий", "Тепляков", 1);

            Assert.That(validChildGirl.Husband, Is.EqualTo(childGirl.Husband));
            Assert.That(validChildGirl.Wife, Is.EqualTo(childGirl.Wife));
        }
    }
}

