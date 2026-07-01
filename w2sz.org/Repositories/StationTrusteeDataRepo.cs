using Microsoft.EntityFrameworkCore;
using w2sz.org.Data;
using w2sz.org.Models;

namespace w2sz.org.Repositories
{
    public class StationTrusteeDataRepo : IStationTrusteeDataRepo
    {
        // Define and instantiate the factory that provides the database context
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;
        public StationTrusteeDataRepo(IDbContextFactory<ApplicationDbContext> _contextFactory)
        {
            contextFactory = _contextFactory;
        }

        public async Task<StationTrusteeData> GetStationTrusteeDataAsync()
        {
            // The "using" keyword ensures the context disposes of itself after the operation is complete
            using var context = await contextFactory.CreateDbContextAsync();
            return await context.Trustee.FindAsync(1);
        }
        public async Task UpdateStationTrusteeDataAsync(StationTrusteeData STData)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            context.Trustee.Update(STData);
            await context.SaveChangesAsync();
        }
    }
}
