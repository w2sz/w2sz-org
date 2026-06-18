using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace w2sz.org.Components.Layout
{
    public partial class LeftBanner : ComponentBase
    {
        [Inject]
        public required IJSRuntime JSRuntime { get; set; } 

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        // OnAfterRender used as this involves only parts of the rendered page
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync("onload");
        }
    }
}
