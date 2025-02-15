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
        public bool RegistrationNullError { get; set; } = false;
        public bool RegistrationNotFoundError { get; set; } = false;
        public bool MOTCreatedPass { get; set; } =false;
        public bool MOTAlreadyExists { get; set; } = false ;
        public long UpdatedTestNumber { get; set; }
        public bool MOTNotRequired { get; set; } = false;
        public bool MOTCreatedFail { get; set; }
    }
}
