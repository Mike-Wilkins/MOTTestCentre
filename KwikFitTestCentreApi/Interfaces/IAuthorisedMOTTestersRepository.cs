using KwikFitTestCentreApi.Models;

namespace KwikFitTestCentreApi.Interfaces
{
    public interface IAuthorisedMOTTestersRepository
    {
        ICollection<AuthorisedMOTTesters> GetAuthorisedTesters();
        AuthorisedMOTTesters GetAuthorisedMOTTester(int Id);
        bool Add(AuthorisedMOTTesters authorisedMOTTesters);
        bool Save();
        bool Update(AuthorisedMOTTesters authorisedMOTTester);
        bool Delete(AuthorisedMOTTesters authorisedMOTTester);
        bool TesterExists(int Id);
    }
}
