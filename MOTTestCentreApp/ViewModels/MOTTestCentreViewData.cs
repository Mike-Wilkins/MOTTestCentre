using KwikFitTestCentreApi.Interfaces;
using KwikFitTestCentreApi.Models;
using MOTTestCentreApp.Interfaces;

namespace MOTTestCentreApp.ViewModels
{
    public class MOTTestCentreViewData : IMOTTestCentreViewData
    {
        public AuthorisedMOTTesters authorisedMOTTesters { get; set; }
        public MOTStatusDetails statusDetails { get; set; }
        public MOTTestCertificateDetails certificateDetails { get; set; }
    }
}
