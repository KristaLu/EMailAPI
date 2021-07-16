using Microsoft.Extensions.Logging;
using MimeKit;
using System;

namespace EMailAPI
{
    public class MessageBuilder
    {
        public string From { get; } = "From";
        public string FromAddress { get; } = "login@gmail.com";
        public string To { get; } = "To";
        public string ToAddress { get; set; }
        public string Subject { get; } = "Subject";
        public string Body { get; } = "<b>Hi!</b> <i>Hi!</i> <tt>Hi!</tt>";
        public string Attachment { get; } = "E:\\cat.jpg";

    }
}
