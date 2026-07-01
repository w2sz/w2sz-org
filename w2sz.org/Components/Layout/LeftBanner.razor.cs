using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

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
            try
            {
                await JSRuntime.InvokeVoidAsync("onload");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to call JS onload() method");
            }
        }
    }
}
