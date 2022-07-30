using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using Massenger.Core.DTO;
using Massenger.Core.Service;
using MimeKit;

namespace Massenger.Infra.Service
{
    public class emailclass : IEmailservice
    {
        public string GetEmail(emailmessage mes)
        {
            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("User", "sajatawalbeh99@gmail.com");
            MailboxAddress to = new MailboxAddress("user", mes.Email);

            builder.HtmlBody = "<h1>" + mes.message + "</h1>";

            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "Block Notification";
            using (var item = new SmtpClient())
            {
                item.Connect("smtp.gmail.com", 587, false);
                item.Authenticate("sajatawalbeh99@gmail.com", "aopolsyfzzvizglm");
                item.Send(message);
                item.Disconnect(true);

            }

            return "true";
        }
    }
}

