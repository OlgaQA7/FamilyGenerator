using WebApi.Contracts;
using WebApi.Helpers.Interfaces;

namespace WebApi.Helpers
{
    public class ChildGenerator : IChildGenerator
    {
        private static readonly string[] NameWomanArr = new[]
        {
            "Светлана",
            "Ксения",
            "Александра",
            "Мария",
            "Лариса",
            "Ангелина",
            "Анжела",
            "Лидия",
            "Алла",
            "Татьяна"
        };

        private static readonly Dictionary<string, string[]> NameManArr = new Dictionary<string, string[]>
        {
            { "Дмитрий", new[] { "Дмитриевич", "Дмитриевна" } },
            { "Максим", new[] { "Максимович", "Максимовна" } },
            { "Петр", new[] { "Петрович", "Петровна" } },
            { "Василий", new[] { "Васильевич", "Васильевна" } },
            { "Сергей", new[] { "Сергеевич", "Сергеевна" } },
            { "Матвей", new[] { "Матвеевич", "Матвеевна" } },
            { "Николай", new[] { "Николаевич", "Николаевна" } },
            { "Михаил", new[] { "Михайлович", "Михайловна" } },
            { "Андрей", new[] { "Андреевич", "Андреевна" } },
            { "Арсений", new[] { "Арсеньевич", "Арсеньевна" } },
            { "Леонид", new[] { "Леонидович", "Леонидовна" } },
            { "Алексей", new[] { "Алексеевич", "Алексеевна" } },
            { "Лев", new[] { "Львович", "Львовна" } },
            { "Константин", new[] { "Константинович", "Константиновна" } },
            { "Владимир", new[] { "Владимирович", "Владимировна" } },
        };

        private static readonly Dictionary<string, string> LastNames = new Dictionary<string, string>
        {
            { "Тепляков", "Теплякова" },
            { "Огурцов","Огурцова"},
            { "Климов","Климова"},
            { "Морозов","Морозова"},
            { "Петров","Петрова"},
            { "Иванов","Иванова"},
            { "Васильев","Васильева"},
            { "Соколов","Соколова"},
            { "Михеев","Михеева"},
            { "Левченко","Левченко"},
            { "Ковалев","Ковалева"},
            { "Кузнецов","Кузнецова"},
            { "Борисов", "Борисова"},
            { "Николаев", "Николаева" },
            { "Карпов", "Карпова"},
            { "Окунев", "Окунева"},
            { "Баклажанов", "Баклажанова"},
            { "Кабачков", "Кабачкова"},
            { "Салоедов", "Салоедова"},
            { "Сосисочкин", "Сосисочкина"}
        };

        public Family CalculateChild(string fatherName, string fatherLastName, int generation)
        {
            var isMan = Random.Shared.Next(0, 2) == 1;
            var isWoman = Random.Shared.Next(0, 2) == 0;

            if (isMan)
            {
                var husbandLastName = fatherLastName;
                var husbandName = NameManArr.Keys.ElementAt(Random.Shared.Next(0, NameManArr.Count));
                var husbandMiddleName = NameManArr[fatherName][0];
                var husbandFullName = $"{husbandLastName} {husbandName} {husbandMiddleName}";

                var wifeLastName = LastNames[husbandLastName];
                var wifeName = NameWomanArr[Random.Shared.Next(0, NameWomanArr.Length)];
                var wifeMiddleName = NameManArr.Values.ElementAt(Random.Shared.Next(0, NameManArr.Count))[1];
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
                var husbandLastName = LastNames.Keys.ElementAt(Random.Shared.Next(1, LastNames.Count));
                var husbandName = NameManArr.Keys.ElementAt(Random.Shared.Next(0, NameManArr.Count));
                var husbandMiddleName = NameManArr.Values.ElementAt(Random.Shared.Next(0, NameManArr.Count))[0];
                var husbandFullName = $"{husbandLastName} {husbandName} {husbandMiddleName}";

                var wifeLastName = LastNames[husbandLastName];
                var wifeName = NameWomanArr[Random.Shared.Next(0, NameWomanArr.Length)];
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
