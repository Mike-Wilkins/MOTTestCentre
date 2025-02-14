using KwikFitTestCentreApi.Models;

namespace MOTTestCentreApp.Interfaces
{
    public interface IMOTTestCentreViewData
    {
        public AuthorisedMOTTesters authorisedMOTTesters { get; set; }
        public MOTStatusDetails statusDetails { get; set; }
        public MOTTestCertificateDetails certificateDetails { get; set; }
        public bool RegistrationNullError { get; set; }
        public bool RegistrationNotFoundError { get; set; } 
        public bool MOTCreatedSuccess { get; set; }
        public bool MOTAlreadyExists { get; set; }
        public long UpdatedTestNumber { get; set; }
        public bool MOTNotRequired { get; set; }
      
    }
}
