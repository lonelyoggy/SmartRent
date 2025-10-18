using SmartRent.Models;
namespace SmartRent.Interfaces
{
    public interface IApartmentService
    {
        Task<IEnumerable<Apartment>> GetAllAsync();
        Task<Apartment> GetByIdAsync(int id);
        Task<Apartment> CreateAsync(Apartment apartment);
        Task<Apartment> UpdateAsync(int id, Apartment apartment);
        Task<bool> DeleteAsync(int id);
    }
}
