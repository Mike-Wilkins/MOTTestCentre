using KwikFitTestCentreApi.Interfaces;
using KwikFitTestCentreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KwikFitTestCentreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorisedMOTTestersController : Controller
    {
        private readonly IAuthorisedMOTTestersRepository _authorisedTesterRepository;

        public AuthorisedMOTTestersController(IAuthorisedMOTTestersRepository authorisedTestersRepository)
        {
            _authorisedTesterRepository = authorisedTestersRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorisedMOTTesters>))]
        public IActionResult GetTesterDetails()
        {
            var testerDetails = _authorisedTesterRepository.GetAuthorisedTesters();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(testerDetails);
        }

        [HttpGet("{customerId}")]
        [ProducesResponseType(200, Type = typeof(AuthorisedMOTTesters))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorisedMOTTester(int Id)
        {
            if (!_authorisedTesterRepository.TesterExists(Id))
                return NotFound();

            var testDetail = _authorisedTesterRepository.GetAuthorisedMOTTester(Id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(testDetail);
        }



    }
}
