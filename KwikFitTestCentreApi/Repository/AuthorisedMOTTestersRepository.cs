using KwikFitTestCentreApi.Data;
using KwikFitTestCentreApi.Interfaces;
using KwikFitTestCentreApi.Models;

namespace KwikFitTestCentreApi.Repository
{
    public class AuthorisedMOTTestersRepository : IAuthorisedMOTTestersRepository
    {
        private readonly DataContext _context;
        public AuthorisedMOTTestersRepository(DataContext context)
        {
            _context = context;
        }
        public bool Add(AuthorisedMOTTesters authorisedMOTTesters)
        {
            _context.AuthorisedMOTTesters.Add(authorisedMOTTesters);
            return Save();
        }

        public bool Delete(AuthorisedMOTTesters authorisedMOTTester)
        {
            _context.AuthorisedMOTTesters.Remove(authorisedMOTTester);
            return Save();
        }

        public AuthorisedMOTTesters GetAuthorisedMOTTester(int Id)
        {
            return _context.AuthorisedMOTTesters.Where(at => at.Id == Id).FirstOrDefault();
        }

        public ICollection<AuthorisedMOTTesters> GetAuthorisedTesters()
        {
            return _context.AuthorisedMOTTesters.OrderBy(at => at.UserID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(AuthorisedMOTTesters authorisedMOTTester)
        {
            _context.AuthorisedMOTTesters.Update(authorisedMOTTester);
            return Save();
        }
        public bool TesterExists(int Id)
        {
            return _context.AuthorisedMOTTesters.Any(t => t.Id == Id);
        }
    }
}
