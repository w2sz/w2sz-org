using w2sz.org.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Routing
{
    internal static class IdentityComponentsEndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapAdditionalIdentityEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            var accountGroup = endpoints.MapGroup("/admin");

            accountGroup.MapPost("/logout", async (
                ClaimsPrincipal user,
                [FromServices] SignInManager<ApplicationUser> signInManager,
                [FromForm] string returnUrl) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.LocalRedirect($"~/{returnUrl}");
            });

            var manageGroup = accountGroup.MapGroup("/admin/manage-account").RequireAuthorization();

            var loggerFactory = endpoints.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var downloadLogger = loggerFactory.CreateLogger("DownloadPersonalData");

            return accountGroup;
        }
    }
}
