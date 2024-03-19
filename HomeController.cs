using Freelancer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;

namespace Freelancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static List<ErrorViewModel> freelancers = new List<ErrorViewModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult<IEnumerable<ErrorViewModel>> Get()
        {
            return Ok(freelancers);
        }

        [HttpGet("{id}")]
        public ActionResult<ErrorViewModel> GetById(int id)
        {
            var freelancer = freelancers.FirstOrDefault(f => f.Id == id);
            if (freelancer == null)
            {
                return NotFound();
            }
            return Ok(freelancer);
        }

        [HttpPost]
        public ActionResult<ErrorViewModel> Post(ErrorViewModel freelancer)
        {
            freelancer.Id = freelancers.Count + 1;
            freelancers.Add(freelancer);
            return CreatedAtAction(nameof(GetById), new { id = freelancer.Id }, freelancer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ErrorViewModel freelancer)
        {
            var existingFreelancer = freelancers.FirstOrDefault(f => f.Id == id);
            if (existingFreelancer == null)
            {
                return NotFound();
            }
            existingFreelancer.Username = freelancer.Username;
            existingFreelancer.Email = freelancer.Email;
            existingFreelancer.PhoneNumber = freelancer.PhoneNumber;
            existingFreelancer.Skillsets = freelancer.Skillsets;
            existingFreelancer.Hobby = freelancer.Hobby;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingFreelancer = freelancers.FirstOrDefault(f => f.Id == id);
            if (existingFreelancer == null)
            {
                return NotFound();
            }
            freelancers.Remove(existingFreelancer);
            return NoContent();
        }
    }
}
