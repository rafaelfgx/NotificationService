using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NotificationService
{
    [Route("emails")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync(Email email)
        {
            var result = await _emailService.SendAsync(email);

            if (!result.Succeeded)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
