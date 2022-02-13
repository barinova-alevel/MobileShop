namespace Catalog.Host.Repositories.Interfaces
{
    public interface ILaptopScreenTypeRepository
    {
        Task<int?> Add(string screenType);

        Task<int?> Update(int id, string name);

        Task<int?> Remove(int id);

    }
}
