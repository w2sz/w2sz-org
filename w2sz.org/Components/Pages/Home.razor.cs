using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace w2sz.org.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Parameter]
        public string? coverImageClass { get; set; } = "rotating_image";

        protected override async Task OnInitializedAsync()
        {
            //coverImageClass = "fade_in";
        }
    }
}
