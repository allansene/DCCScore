using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DCCStore.MVC.Services
{
    public class EmailService : IIdentityMessageService
    {

        private const string SENDGRID_APIKEY = "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";

        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            var myMessage = new SendGrid.SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new MailAddress("no-reply@dccscore.com", "DCC Score");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;

            var transportWeb = new SendGrid.Web(SENDGRID_APIKEY);

            transportWeb.DeliverAsync(myMessage).Wait();
            return Task.FromResult(0);
        }
    }
}