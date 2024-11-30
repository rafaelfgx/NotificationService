namespace NotificationService;

[Route("emails")]
[ApiController]
public class EmailController(IEmailService emailService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendAsync(Email email)
    {
        var result = await emailService.SendAsync(email);

        if (result.IsError) return BadRequest(result.Message);

        return Ok();
    }
}
