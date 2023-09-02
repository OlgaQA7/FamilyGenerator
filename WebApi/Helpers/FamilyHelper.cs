using WebApi.Contracts;
using WebApi.Helpers.Interfaces;

namespace WebApi.Helpers
{
    public class FamilyHelper : IFamilyHelper
    {
        private readonly IChildGenerator _childGenerator;

        public FamilyHelper(IChildGenerator childGenerator)
        {
            _childGenerator = childGenerator;
        }

        public FamilyModel GetFamily(int generation)
        {
            // код должен возвращать 
            // древо поколений

            Family family = new Family()
            {
                Husband = "Тепляков Дмитрий Николаевич",
                Wife = "Левченко Ольга Геннадьевна",
                Gender = "Сын",
                Generation = 1,
            };

            var lastGeneration = new[] { family };
            var currentGeneration = new List<Family>();
            for (int i = 1; i < generation; i++)
            {
                foreach (var generationFamily in lastGeneration)
                {
                    generationFamily.NextGeneration = CalculateNextGeneration(generationFamily);
                    
                    currentGeneration.AddRange(generationFamily.NextGeneration);
                }

                lastGeneration = currentGeneration.ToArray();
                currentGeneration.Clear();
            }

            return new FamilyModel()
            {
                Family = family
            };
        }

        private Family[] CalculateNextGeneration(Family family)
        {
            var manNames = family.Husband.Split(' ');
            var manLastName = manNames[0];
            var manFirstName = manNames[1];
            var childrenCount = 2; //Random.Shared.Next(1,3);
            var children = new Family[childrenCount];

            for (int i = 0; i < childrenCount; i++)
            {
                var childFamily = _childGenerator.CalculateChild(manFirstName, manLastName, family.Generation);
                children[i] = childFamily;
            }

            return children;
        }

        
    }
}
