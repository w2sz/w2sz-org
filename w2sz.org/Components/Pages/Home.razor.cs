using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace w2sz.org.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        public required IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference? HomeJSModule { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Import the JS module used to load the cover image
                HomeJSModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Components/Pages/Home.razor.js");

                // Get the array of all possible cover images
                //   * Select is used here to convert all of the full paths to just the filenames
                IEnumerable<String> coverImages = Directory.GetFiles("./wwwroot/Images/CoverImages").Select(f => Path.GetFileName(f));

                // Select a random image from the discovered image files
                string imageSource = coverImages.ElementAt(Random.Shared.Next(coverImages.Count()));

                // Call the JS function to load the selected image
                await HomeJSModule.InvokeVoidAsync("loadImage", imageSource);
            }
        }
    }
}
