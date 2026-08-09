using w2sz.org.Models;
using w2sz.org.Repositories;

namespace w2sz.org.Data
{
    public class ApplicationState
    {
        private readonly IOfficerDataRepo officerDataRepo;

        // Contains a static copy of the officer data to only be updated when null or on refresh
        private List<OfficerData>? officers = null;

        public ApplicationState(IOfficerDataRepo _officerDataRepo)
        {
            officerDataRepo = _officerDataRepo;
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
    }
}
