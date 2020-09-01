using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Services.SMTP
{
    public interface IMailingService
    {
        void SendEmail(EMailModel emailModel);
    }
}
