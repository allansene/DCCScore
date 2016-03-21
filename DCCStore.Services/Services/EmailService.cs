using DCCScore.Utils.Parametrizacao;
using DCCScore.Services.Services;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DCCScore.Services
{
    public class EmailService : IIdentityMessageService
    {

        IParametrosService _parametroService;

        public EmailService()
        {
            _parametroService = new ParametrosService();
        }
       
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            var myMessage = new SendGrid.SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new MailAddress("no-reply@dccscore.com", "DCC Score");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            var password = Base64Coder.Base64Decode(_parametroService.getParametro("pass_usergrid"));

            var transportWeb = new SendGrid.Web(
                _parametroService.getParametro("key_sendgrid"), 
                new System.Net.NetworkCredential(
                    _parametroService.getParametro("user_sendgrid"),
                    password
                    ),
                new System.TimeSpan(0,1,0)
            );

            transportWeb.DeliverAsync(myMessage).Wait();
            return Task.FromResult(0);
        }
    }
}