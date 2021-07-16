using Microsoft.Extensions.Logging;
using MimeKit;
using System;

namespace EMailAPI
{
    public class PostServer
    {
        public string Host { get; } = "smtp.gmail.com";
        public int Port { get; } = 465;
        public bool UseSsl { get; } = true;
        public string UserName { get; } = "login@gmail.com";
        public string Password { get; } = "password";

    }
}
