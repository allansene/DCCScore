using DCCStore.Services.Services;
using Microsoft.AspNet.Identity;
using Sinco.Configuracao;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DCCStore.MVC.Services
{
    public class EmailService : IIdentityMessageService
    {

        private const string SENDGRID_APIKEY = "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";
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

            var transportWeb = new SendGrid.Web(SENDGRID_APIKEY, 
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