using w2sz.org.Models;
using w2sz.org.Repositories;

namespace w2sz.org.Data
{
    public class ApplicationState
    {
        private readonly IOfficerDataRepo officerDataRepo;
        private readonly IStationTrusteeDataRepo trusteeDataRepo;

        // Contains a static copy of the officer data to only be updated when null or on refresh
        private List<OfficerData>? officers = null;
        private StationTrusteeData? trustee = null;

        public ApplicationState(IOfficerDataRepo _officerDataRepo, IStationTrusteeDataRepo _trusteeDataRepo)
        {
            officerDataRepo = _officerDataRepo;
            trusteeDataRepo = _trusteeDataRepo
        }
        public async Task RefreshAllOfficersAsync()
        {
            officers = await officerDataRepo.PullAllOfficersAsync();
        }
        public async Task<List<OfficerData>> GetAllOfficersAsync()
        {
            if (officers == null)
            {
                officers = await officerDataRepo.PullAllOfficersAsync();
            }

            return officers;
        }

        public async Task RefreshTrusteeAsync()
        {
            trustee = await trusteeDataRepo.GetStationTrusteeDataAsync();
        }
        public async Task<StationTrusteeData> GetStationTrusteeDataAsync()
        {
            if (trustee == null)
            {
                trustee = await trusteeDataRepo.PullStationTrusteeDataAsync();
            }

            return trustee;
        }
    }
}
