using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly GmailSmtpClient _gmailSmtpClient;

        public EmailController(IConfiguration configuration)
        {
            string gmailAddress = configuration["Gmail:Address"];
            string gmailPassword = configuration["Gmail:Password"];
            _gmailSmtpClient = new GmailSmtpClient(gmailAddress, gmailPassword);
        }

        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] EmailRequest emailRequest)
        {
            _gmailSmtpClient.SendEmail(emailRequest.ToAddress, emailRequest.Subject, emailRequest.Body, emailRequest.IsBodyHtml);
            return Ok("Email sent successfully.");
        }
    }
}

