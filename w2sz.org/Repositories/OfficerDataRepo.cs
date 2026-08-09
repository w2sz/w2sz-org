using Microsoft.EntityFrameworkCore;
using w2sz.org.Data;
using w2sz.org.Models;

namespace w2sz.org.Repositories
{
    public class OfficerDataRepo : IOfficerDataRepo
    {
        // Define and instantiate the factory that provides the database context
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;
        public OfficerDataRepo(IDbContextFactory<ApplicationDbContext> _contextFactory)
        {
            contextFactory = _contextFactory;
        }

        public async Task<List<OfficerData>> PullAllOfficersAsync()
        {
            Console.WriteLine("Pulling from DB");
            // The "using" keyword ensures the context disposes of itself after the operation is complete
            using var context = await contextFactory.CreateDbContextAsync();
            return await context.Officers.AsNoTracking().ToListAsync();
        }
        public async Task<OfficerData?> GetOfficerByIDAsync(int id)
        {
            // The "using" keyword ensures the context disposes of itself after the operation is complete
            using var context = await contextFactory.CreateDbContextAsync();
            return await context.Officers.FindAsync(id);
        }
        public async Task UpdateOfficerDataAsync(OfficerData Officer)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            context.Officers.Update(Officer);
            await context.SaveChangesAsync();
        }
    }
}
