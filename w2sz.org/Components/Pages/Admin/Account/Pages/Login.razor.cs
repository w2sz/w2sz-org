using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using w2sz.org.Data;

namespace w2sz.org.Components.Pages.Admin.Account.Pages
{
    public partial class Login : ComponentBase
    {
        private string? errorMessage;
        private EditContext editContext = default!;

        [CascadingParameter]
        private HttpContext HttpContext { get; set; } = default!;
        [SupplyParameterFromForm]
        private InputModel Input { get; set; } = default!;
        private string ReturnUrl { get; set; } = "/admin";

        [Inject]
        public required UserManager<ApplicationUser> UserManager { get; set; }
        [Inject]
        public required SignInManager<ApplicationUser> SignInManager { get; set; }
        [Inject]
        public required ILogger<Login> Logger { get; set; }
        [Inject]
        public required NavigationManager NavMan { get; set; }
        [Inject]
        private IdentityRedirectManager? RedirectManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Input ??= new();
            editContext = new EditContext(Input);
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
                // Clear the existing external cookie to ensure a clean login process
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            }
        }

        public async Task LoginUser()
        {
            if (RedirectManager is null)
            {
                errorMessage = "Error: RedirectManager cannot be a null value";
                return;
            }

            // Define the variable to hold the result of the sign in attempt
            SignInResult result;

            // Validate the form.
            if (!editContext.Validate()) { return; }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            result = await SignInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                Logger.LogInformation("User logged in.");
                RedirectManager.RedirectTo(ReturnUrl);
            }
            else
            {
                errorMessage = "Error: Invalid login attempt.";
            }
        }

        private sealed class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = "";

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = "";

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
    }
}
