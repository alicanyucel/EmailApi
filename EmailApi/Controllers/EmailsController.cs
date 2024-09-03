using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.ToEmail))
        {
            return BadRequest("Invalid email request");
        }

        await _emailService.SendEmailAsync(request.ToEmail, request.Subject, request.Message);
        return Ok("Email sent successfully");
    }
}

public class EmailRequest
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
