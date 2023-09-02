using WebApi.Helpers.Interfaces;
using static WebApi.Data.DictionaryNames;

namespace WebApi.Helpers
{
    public class RandomChildHelper : IRandomChildHelper
    {  
        public bool GetGenderRandom()
        {
            var isMan = Random.Shared.Next(0, 2) == 1;
            return isMan;
        }

        public string GetManLastName()
        {
            var manLastName = LastNames.Keys.ElementAt(Random.Shared.Next(1, LastNames.Count));
            return manLastName;
        }

        public string GetRandomManName()
        {
            var manName = NameManArr.Keys.ElementAt(Random.Shared.Next(0, NameManArr.Count));
            return manName;
        }

        public string GetRandomWomanName()
        {
            var womanName = NameWomanArr[Random.Shared.Next(0, NameWomanArr.Length)];
            return womanName;
        }

        public string GetWomanMiddleName()
        {
            var womanMiddleName = NameManArr.Values.ElementAt(Random.Shared.Next(0, NameManArr.Count))[1];
            return womanMiddleName;
        }

        public string GetRandomManMiddleName()
        {
            var manMiddleName = NameManArr.Values.ElementAt(Random.Shared.Next(0, NameManArr.Count))[0];
            return manMiddleName;
        }

       
    }
}
