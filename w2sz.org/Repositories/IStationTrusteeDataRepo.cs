using w2sz.org.Models;

namespace w2sz.org.Repositories
{
    public interface IStationTrusteeDataRepo
    {
        Task<StationTrusteeData> PullStationTrusteeDataAsync();
        Task UpdateStationTrusteeDataAsync(StationTrusteeData STData);
    }
}
