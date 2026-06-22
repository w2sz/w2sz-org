using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using w2sz.org.Data;

namespace w2sz.org.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Ignore the IdentityPasskeyData entity type as we are not using passkeys and the database is not compatible for them
            var entityTypes = typeof(IdentityPasskeyData).Assembly.GetTypes()
                .Where(t => typeof(IdentityPasskeyData).IsAssignableFrom(t)).ToArray();
            foreach (var type in entityTypes)
            {
                builder.Ignore(type);
            }
        }
    }
}
