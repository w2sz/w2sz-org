using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using w2sz.org.Components.Pages.Home;
using w2sz.org.Models;

namespace w2sz.org.Components.Pages.Admin
{
    public partial class EditContacts : ComponentBase
    {
        private OfficerList? officerCompRef;
        private StationTrustee? trusteeCompRef;  

        private List<OfficerData>? officers;
        private StationTrusteeData? trustee;

        private List<InputModelOfficer> dynamicOfficerList = default!;
        private List<InputModelTrustee> dynamicTrusteeDisp = default!;

        [Inject]
        public required NavigationManager NavMan { get; set; }

        protected override async Task OnInitializedAsync()
        {
            officers = await State.GetAllOfficersAsync();
            trustee  = await State.GetStationTrusteeDataAsync();

            if (officers != null)
            {
                //   Create a dynamic list of inputs from the obtained list of
                // officer data that can be used to bind to the form in the page
                dynamicOfficerList = new List<InputModelOfficer>(officers.Count);
                for (int i = 0; i < officers.Count; i++)
                {
                    OfficerData officer = officers[i];
                    InputModelOfficer newDynamicOfficer = new InputModelOfficer();
                    // Sets the data obtained from the table into the dynamic bound list
                    // Uses an empty string on the off chance the value is null
                    newDynamicOfficer.DBID            = officer.ID;
                    newDynamicOfficer.OfficerTitle    = officer.Position == null ? "" : officer.Position;
                    newDynamicOfficer.OfficerName     = officer.Name == null ? "" : officer.Name;
                    newDynamicOfficer.OfficerCallsign = officer.Callsign == null ? "" : officer.Callsign;
                    newDynamicOfficer.OfficerEmail    = officer.Email == null ? "" : officer.Email;
    
                    dynamicOfficerList.Add(newDynamicOfficer);
                }
            }
            
            if (trustee != null) 
            {
                // Same as above but for the single trustee entry
                dynamicTrusteeDisp = new List<InputModelTrustee>(1);
                InputModelTrustee newDynamicTrustee = new InputModelTrustee();
                // Sets the data obtained from the table into the dynamic bound list
                // Uses an empty string on the off chance the value is null
                newDynamicTrustee.DBID            = trustee.ID;
                newDynamicTrustee.TrusteePrefix   = trustee.Prefix;
                newDynamicTrustee.TrusteeName     = trustee.Name;
                newDynamicTrustee.TrusteeCallsign = trustee.Callsign;
                newDynamicTrustee.TrusteeEmail    = trustee.Email;
    
                dynamicTrusteeDisp.Add(newDynamicTrustee);
            }
        }

        public async Task EditOfficerData()
        {
            if (dynamicOfficerList != null)
            {
                foreach (var dynamicOfficer in dynamicOfficerList)
                {
                    // The db context update function requires the original OfficerData object
                    OfficerData officer = new OfficerData();
                    officer.ID       = dynamicOfficer.DBID;
                    officer.Position = dynamicOfficer.OfficerTitle;
                    officer.Name     = dynamicOfficer.OfficerName;
                    officer.Callsign = dynamicOfficer.OfficerCallsign;
                    officer.Email    = dynamicOfficer.OfficerEmail;

                    await _OfficerDataRepo.UpdateOfficerDataAsync(officer);
                }
            }
            // Refresh the preview
            officerCompRef?.Refresh();
        }

        public async Task EditTrusteeData()
        {
            if (dynamicTrusteeDisp != null)
            {
                foreach (var dynamicTrustee in dynamicTrusteeDisp) 
                {
                    // The db context update function requiores the original StationTrusteeData object
                    StationTrusteeData trustee = new StationTrusteeData();
                    trustee.ID       = dynamicTrustee.DBID;
                    trustee.Prefix   = dynamicTrustee.TrusteePrefix;
                    trustee.Name     = dynamicTrustee.TrusteeName;
                    trustee.Callsign = dynamicTrustee.TrusteeCallsign;
                    trustee.Email    = dynamicTrustee.TrusteeEmail;

                    await _StationTrusteeDataRepo.UpdateStationTrusteeDataAsync(trustee);
                }
            }
            // Refresh the preview
            trusteeCompRef?.Refresh();
        }

        private sealed class InputModelOfficer
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
        
        private sealed class InputModelTrustee
        {
            public int DBID { get; set; }

            [Required]
            public string TrusteePrefix { get; set; } = "";

            [Required]
            public string TrusteeName { get; set; } = "";

            [Required]
            public string TrusteeCallsign { get; set; } = "";

            [Required]
            public string TrusteeEmail { get; set; } = "";
        }
    }
}
