using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using w2sz.org.Data;

namespace w2sz.org.Components.Pages.Admin.Account.Pages
{
    public partial class ConfirmEmail : ComponentBase
    {
        [Inject]
        protected UserManager<ApplicationUser> UserManager { get; set; } = default!;
        [Inject]
        private IdentityRedirectManager RedirectManager { get; set; } = default!;

        private string? statusMessage;
        [CascadingParameter]
        private HttpContext HttpContext { get; set; } = default!;
        [SupplyParameterFromQuery]
        private string? UserId { get; set; }
        [SupplyParameterFromQuery]
        private string? Code { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (UserId is null || Code is null)
            {
                RedirectManager.RedirectTo("");
                return;
            }

            var user = await UserManager.FindByIdAsync(UserId);
            if (user is null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                statusMessage = $"Error loading user with ID {UserId}";
            }
            else
            {
                var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(Code));
                var result = await UserManager.ConfirmEmailAsync(user, code);
                statusMessage = result.Succeeded ? "Thank you for confirming your email. Now go back and login with these credentials." : "Error confirming your email.";
            }
        }
    }
}
