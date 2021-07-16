using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMailAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EMailController : ControllerBase
    {
        private readonly ILogger<EMailController> _logger;
        private readonly EMailSender Sender;

        public EMailController(ILogger<EMailController> logger)
        {
            _logger = logger;
            this.Sender = new EMailSender();
        }

        [HttpPost]
        public void Post(string email)
        {
            Sender.Send(email);
        }
    }
}
