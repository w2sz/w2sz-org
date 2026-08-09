using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using w2sz.org.Components.Pages.Home;
using w2sz.org.Models;

namespace w2sz.org.Components.Pages.Admin
{
    public partial class EditContacts : ComponentBase
    {
        private OfficerList? officerCompRef;

        private List<OfficerData>? officers;

        private List<InputModel> dynamicOfficerList = default!;

        [Inject]
        public required NavigationManager NavMan { get; set; }

        protected override async Task OnInitializedAsync()
        {
            officers = await State.GetAllOfficersAsync();

            //   Create a dynamic list of inputs from the obtained list of
            // officer data that can be used to bind to the form in the page
            dynamicOfficerList = new List<InputModel>(officers.Count);
            for (int i = 0; i < officers.Count; i++)
            {
                OfficerData officer = officers[i];
                InputModel newDynamicOfficer = new InputModel();
                // Sets the data obtained from the table into the dynamic bound list
                // Uses an empty string on the off chance the value is null
                newDynamicOfficer.DBID = officer.ID;
                newDynamicOfficer.OfficerTitle = officer.Position == null ? "" : officer.Position;
                newDynamicOfficer.OfficerName = officer.Name == null ? "" : officer.Name;
                newDynamicOfficer.OfficerCallsign = officer.Callsign == null ? "" : officer.Callsign;
                newDynamicOfficer.OfficerEmail = officer.Email == null ? "" : officer.Email;

                dynamicOfficerList.Add(newDynamicOfficer);
            }
        }

        public async Task EditContactData()
        {
            if (dynamicOfficerList != null)
            {
                foreach (var dynamicOfficer in dynamicOfficerList)
                {
                    // The db context update function requires the original OfficerData object
                    OfficerData officer = new OfficerData();
                    officer.ID = dynamicOfficer.DBID;
                    officer.Position = dynamicOfficer.OfficerTitle;
                    officer.Name = dynamicOfficer.OfficerName;
                    officer.Callsign = dynamicOfficer.OfficerCallsign;
                    officer.Email = dynamicOfficer.OfficerEmail;

                    await _OfficerDataRepo.UpdateOfficerDataAsync(officer);
                }
            }
            // Refresh the preview
            officerCompRef?.Refresh();
        }

        private sealed class InputModel
        {
            public int DBID { get; set; }

            [Required]
            public string OfficerTitle { get; set; } = "";

            [Required]
            public string OfficerName { get; set; } = "";

            [Required]
            public string OfficerCallsign { get; set; } = "";

            [Required]
            public string OfficerEmail { get; set; } = "";
        }
    }
}
