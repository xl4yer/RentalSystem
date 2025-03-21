using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace RentalSystem.Controllers
{
    public class EmailController : Controller
    {
        [HttpPost("SendEmail")]
        public IActionResult SendEmail(string toAddress, string subject, string body)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("axellevi2024@hotmail.com");
                    mail.To.Add(toAddress);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.office365.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("axellevi2024@hotmail.com", "@May171997");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
