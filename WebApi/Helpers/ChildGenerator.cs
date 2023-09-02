using WebApi.Contracts;
using WebApi.Helpers.Interfaces;
using static WebApi.Data.DictionaryNames;

namespace WebApi.Helpers
{

    public class ChildGenerator : IChildGenerator
    {
        private readonly IRandomChildHelper _randomChildHelper;

        public ChildGenerator(IRandomChildHelper randomChildHelper)
        {
            _randomChildHelper = randomChildHelper;
        }

        public Family CalculateChild(string fatherName, string fatherLastName, int generation)
        {
            var isMan = _randomChildHelper.GetGenderRandom();

            if (isMan)
            {
                var husbandLastName = fatherLastName;
                var husbandName = _randomChildHelper.GetRandomManName();
                var husbandMiddleName = NameManArr[fatherName][0];
                var husbandFullName = $"{husbandLastName} {husbandName} {husbandMiddleName}";

                var wifeLastName = LastNames[husbandLastName];
                var wifeName = _randomChildHelper.GetRandomWomanName();
                var wifeMiddleName = _randomChildHelper.GetWomanMiddleName();
                var wifeFullName = $"{wifeLastName} {wifeName} {wifeMiddleName}";

                return new Family()
                {
                    Husband = husbandFullName,
                    Wife = wifeFullName,
                    Gender = "Сын",
                    Generation = generation + 1,
                };
            }
            else
            {
                var husbandLastName = _randomChildHelper.GetManLastName();
                    //LastNames.Keys.ElementAt(Random.Shared.Next(1, LastNames.Count));
                var husbandName = _randomChildHelper.GetRandomManName();
                var husbandMiddleName = _randomChildHelper.GetRandomManMiddleName();
                    //NameManArr.Values.ElementAt(Random.Shared.Next(0, NameManArr.Count))[0];
                var husbandFullName = $"{husbandLastName} {husbandName} {husbandMiddleName}";

                var wifeLastName = LastNames[husbandLastName];
                var wifeName = _randomChildHelper.GetRandomWomanName();
                var wifeMiddleName = NameManArr[fatherName][1];
                var wifeFullName = $"{wifeLastName} {wifeName} {wifeMiddleName}";

                return new Family()
                {
                    Husband = husbandFullName,
                    Wife = wifeFullName,
                    Gender = "Дочь",
                    Generation = 1,
                };
            }
        }
    }
}
