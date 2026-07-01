using w2sz.org.Models;

namespace w2sz.org.Repositories
{
    public interface IOfficerDataRepo
    {
        Task<List<OfficerData>> GetAllOfficersAsync();
        Task<OfficerData>? GetOfficerByIDAsync(int id);
        Task UpdateOfficerDataAsync(OfficerData Officer);
    }
}
