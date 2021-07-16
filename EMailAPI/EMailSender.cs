using Microsoft.Extensions.Logging;
using MimeKit;
using System;

namespace EMailAPI
{
    public class EMailSender
    {
        private PostServer _server;
        private MessageBuilder _message;

        public EMailSender() 
        {
            _server = new PostServer();
            _message = new MessageBuilder();
        }

        public void Send(string to)
        {
            _message.ToAddress = to;
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(_message.From, _message.FromAddress));
                message.To.Add(new MailboxAddress(_message.To, _message.ToAddress));
                message.Subject = _message.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = _message.Body;
                builder.Attachments.Add(_message.Attachment);
                message.Body = builder.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("host: " + _server.Host + " port: " + _server.Port);
                    Console.WriteLine("Sending to " + _message.ToAddress);

                    client.Connect(_server.Host, _server.Port, _server.UseSsl);
                    client.Authenticate(_server.UserName, _server.Password);
                    client.Send(message);
                    client.Disconnect(true);

                    Console.WriteLine("Done");
                    Console.ResetColor();
                }
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.GetBaseException().Message);
                Console.ResetColor();
            }
        }
    }
}
