namespace WebApi.Helpers.Interfaces
{
    public interface IRandomChildHelper
    {
        bool GetGenderRandom();
        string GetManLastName();               
        string GetRandomManName();
        string GetRandomManMiddleName();
        string GetRandomWomanName();
        string GetWomanMiddleName();
    }
}