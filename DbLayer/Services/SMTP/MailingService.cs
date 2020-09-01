using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CoreLayer.Services.SMTP
{

    public class EMailModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHTML { get; set; }

    }
    public class MailingService : IMailingService
    {
        private string _host;
        private string _from;
        private string _alias;
        public MailingService(IConfiguration iConfiguration)
        {
            var smtpSection = iConfiguration.GetSection("SMTP");
            if (smtpSection != null)
            {
                _host = smtpSection.GetSection("Host").Value;
                _from = smtpSection.GetSection("From").Value;
                _alias = smtpSection.GetSection("Alias").Value;
            }
        }
        public void SendEmail(EMailModel emailModel)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(_host))
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(_from, _alias);
                    mailMessage.BodyEncoding = Encoding.UTF8;

                    mailMessage.To.Add(emailModel.To);
                    mailMessage.Body = emailModel.Body;
                    mailMessage.Subject = emailModel.Subject;
                    mailMessage.IsBodyHtml = emailModel.IsHTML;
                    client.Send(mailMessage);
                }
            }
            catch(Exception e)
            {
                //Log
                throw e;
            }
        }
    }
}
