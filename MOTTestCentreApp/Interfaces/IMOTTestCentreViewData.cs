using KwikFitTestCentreApi.Models;

namespace MOTTestCentreApp.Interfaces
{
    public interface IMOTTestCentreViewData
    {
        public AuthorisedMOTTesters authorisedMOTTesters { get; set; }
        public MOTStatusDetails statusDetails { get; set; }
        public MOTTestCertificateDetails certificateDetails { get; set; }
    }
}
