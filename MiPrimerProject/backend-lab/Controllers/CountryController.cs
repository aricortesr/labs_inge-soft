using backend_lab.Models;
using backend_lab.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService countryService;

        public CountryController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CountryContext");
            countryService = new CountryService(connectionString);
        }

        [HttpGet]
        public List<CountryModel> Get()
        {
            return countryService.GetCountries();
        }
    }
}