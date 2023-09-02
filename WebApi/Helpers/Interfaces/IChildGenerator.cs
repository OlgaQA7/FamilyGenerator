using WebApi.Contracts;

namespace WebApi.Helpers.Interfaces
{
    public interface IChildGenerator
    {
        Family CalculateChild(string fatherName, string fatherLastName, int generation);
    }
}