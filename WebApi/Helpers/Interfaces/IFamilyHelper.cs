using WebApi.Contracts;

namespace WebApi.Helpers.Interfaces
{
    public interface IFamilyHelper
    {
        FamilyModel GetFamily(int generation);
    }
}
