namespace WebApi.Contracts
{
    public class FamilyModel
    {
        public Family Family { get; set; }
    }

    public class Family
    {
        public string fatherLastName;

        public string Husband { get; set; }

        public string Wife { get; set; }

        public string Gender { get; set; }

        public int Generation { get; set; }

        public Family[] NextGeneration { get; set; }
    }
}
