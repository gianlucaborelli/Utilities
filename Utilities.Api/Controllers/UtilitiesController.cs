using Api.Utilities.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Utilities.Controllers
{
    [ApiController]
    [Route("utilities")]
    public class UtilitiesController : ControllerBase
    {
        private readonly IEmailProviderService _service;

        public UtilitiesController(IEmailProviderService service)
        {
            _service = service;
        }

        [HttpGet("check-email-provider")]
        public async Task<ActionResult> LoadUser([FromQuery] string domain)
        {
            try
            {
                if (domain.Contains('@'))
                {
                    string[] parts = domain.Split('@');

                    Ok(await _service.CheckEmailProvider(parts[1]));
                }

                return Ok(await _service.CheckEmailProvider(domain));
            }
            catch
            {
                return Ok(true);
            }
        }
    }
}