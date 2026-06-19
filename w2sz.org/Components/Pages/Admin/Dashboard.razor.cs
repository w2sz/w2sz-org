using Microsoft.AspNetCore.Components;

namespace w2sz.org.Components.Pages.Admin
{
    public partial class Dashboard : ComponentBase
    {
        [Inject]
        public required NavigationManager NavMan { get; set; }

        protected override async Task OnInitializedAsync()
        {
            NavMan.NavigateTo("/admin/login");
        }
    }
}
