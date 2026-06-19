using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace w2sz.org.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Parameter]
        public string? imageSource { get; set; } = "/images/loading.png";

        protected override async Task OnInitializedAsync()
        {
            
        }
    }
}
