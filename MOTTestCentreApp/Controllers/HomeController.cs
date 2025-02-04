using System.Diagnostics;
using KwikFitTestCentreApi.Interfaces;
using KwikFitTestCentreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MOTTestCentreApp.Interfaces;
using MOTTestCentreApp.Models;
using MOTTestCentreApp.ViewModels;

namespace MOTTestCentreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthorisedMOTTestersRepository _authorisedMOTTestersRepository;
        private readonly IMOTTestCentreViewData _viewData;
        private readonly IMOTStatusDetailsRepository _statusDetailsRepository;
        private readonly IMOTTestCertificateDetailsRepository _certificateDetailsRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IAuthorisedMOTTestersRepository authorisedMOTTestersRepository,
            IMOTTestCentreViewData viewData, 
            IMOTStatusDetailsRepository mOTStatusDetailsRepository,
            IMOTTestCertificateDetailsRepository testCertificateDetailsRepository
            )
        {
            _logger = logger;
            _authorisedMOTTestersRepository = authorisedMOTTestersRepository;
            _viewData = viewData;
            _statusDetailsRepository = mOTStatusDetailsRepository;
            _certificateDetailsRepository = testCertificateDetailsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AuthorisedMOTTesters tester)
        {
            ModelState.Remove(nameof(tester.Firstname));
            ModelState.Remove(nameof(tester.Surname));

            if (!ModelState.IsValid) 
            {
                return View(tester);
            }

            var authorisedTesterId = _authorisedMOTTestersRepository.GetAuthorisedTesters().FirstOrDefault(x => x.UserID == tester.UserID);

            ViewBag.TesterExists = true;

            if (authorisedTesterId == null) 
            {
                ViewBag.TesterExists = false;
                return View(tester);
            }

            return RedirectToAction("CreateMOTCert", authorisedTesterId);
        }

        public IActionResult CreateMOTCert(AuthorisedMOTTesters tester)
        {
            _viewData.authorisedMOTTesters = tester;

            return View(_viewData);
        }

        [HttpPost]
        public IActionResult CreateMOTCert(MOTTestCentreViewData registrationNumber)
        {
            var vehileDetails = _statusDetailsRepository.GetStatusDetails().Where(x => x.RegistrationNumber == reg.statusDetails.RegistrationNumber).ToList();

            _viewData.statusDetails = vehileDetails.FirstOrDefault();
            _viewData.authorisedMOTTesters = registrationNumber.authorisedMOTTesters;

            return View(_viewData);
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
