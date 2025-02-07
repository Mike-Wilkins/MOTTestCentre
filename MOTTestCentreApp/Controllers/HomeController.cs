using System.Diagnostics;
using System.Globalization;
using KwikFitTestCentreApi.Interfaces;
using KwikFitTestCentreApi.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateMOTCert(string registration, MOTTestCentreViewData tester)
        {
            if (registration == null && tester.statusDetails.RegistrationNumber == null)
            {
                _viewData.RegistrationNullError = true;
                _viewData.authorisedMOTTesters = tester.authorisedMOTTesters;
                return View(_viewData);
            }

            if (registration == null)
            {
                registration = tester.statusDetails.RegistrationNumber;
            }

            // Check if a vehicle exists on DVLA database
            var vehicleDetails = _statusDetailsRepository.GetStatusDetails().Where(x => x.RegistrationNumber == registration).ToList();

            if (vehicleDetails.Count == 0)
            {
                _viewData.RegistrationNotFoundError = true;
                _viewData.statusDetails = vehicleDetails.FirstOrDefault();
                _viewData.authorisedMOTTesters = tester.authorisedMOTTesters;
                return View(_viewData);
            }

            _viewData.statusDetails = vehicleDetails.FirstOrDefault();
            _viewData.authorisedMOTTesters = tester.authorisedMOTTesters;

            // Need to get latest MOT Certificate.
            // If latest MOT is still valid, we cannot create a new one.
            // If an MOT does not exist (Count = 0), let's create one

            var mOTCertHistory = _certificateDetailsRepository.GetTestCertificateDetails().
                Where(x => x.RegistrationNumber == _viewData.statusDetails.RegistrationNumber).ToList();
            
            if (mOTCertHistory.Count == 0)
            {
                _viewData.statusDetails = vehicleDetails.FirstOrDefault();
                _viewData.authorisedMOTTesters = tester.authorisedMOTTesters;            
            }
            else
            {
                var latestMOTCertNumber = mOTCertHistory.Max(x => x.MOTTestNumber);
                var latestMOTCert = _certificateDetailsRepository.GetTestCertificateDetails().Where(x => x.MOTTestNumber == latestMOTCertNumber).ToList();
                var latestMOTTestDate = DateTime.Parse(latestMOTCert[0].EariestTestDate, new CultureInfo("en-GB", true));

                if (latestMOTTestDate > DateTime.Now && latestMOTCert[0].TestResult == "PASS")
                {
                    _viewData.MOTAlreadyExists = true;
                    _viewData.statusDetails = vehicleDetails.FirstOrDefault();
                    _viewData.authorisedMOTTesters = tester.authorisedMOTTesters;
                    _viewData.certificateDetails = latestMOTCert[0];
                    return View("CreateMOTTestForm", _viewData);
                }
            }

            // Increment MOT Test Number by 1
            var mOtTestNumbers = _certificateDetailsRepository.GetTestCertificateDetails().Where(x => x.MOTTestNumber > 0).ToList();
            var maxTestNumber = mOtTestNumbers.Max(x => x.MOTTestNumber);
            _viewData.certificateDetails = mOtTestNumbers.Where(x => x.MOTTestNumber == maxTestNumber).FirstOrDefault();
            _viewData.certificateDetails.MOTTestNumber = maxTestNumber + 1;

            return View("CreateMOTTestForm", _viewData);
        }

        [HttpPost]
        public IActionResult MOTTestForm(string registration, MOTTestCentreViewData testForm)
        {
            var details = _statusDetailsRepository.GetStatusDetails().Where(x => x.RegistrationNumber == testForm.certificateDetails.RegistrationNumber).ToList();

            _viewData.authorisedMOTTesters = testForm.authorisedMOTTesters;
            _viewData.statusDetails = details.FirstOrDefault();
            _viewData.certificateDetails = testForm.certificateDetails;

            if (testForm.certificateDetails.Mileage == null || 
                testForm.certificateDetails.TestLocation == null ||
                testForm.certificateDetails.TestOrganisation == null ||
                testForm.certificateDetails.InspectorName == null
                )
            {
                return View("CreateMOTTestForm", _viewData);
            }

            _certificateDetailsRepository.Add(testForm.certificateDetails);
            _viewData.MOTCreatedSuccess = true;

            return View("CreateMOTTestForm", _viewData);


        }
    }
}
