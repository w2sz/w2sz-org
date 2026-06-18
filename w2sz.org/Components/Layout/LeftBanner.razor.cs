using Microsoft.AspNetCore.Components;

namespace w2sz.org.Components.Layout
{
    public partial class LeftBanner
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
