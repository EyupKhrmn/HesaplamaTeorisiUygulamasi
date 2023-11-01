using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatGptDeneme.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OpenAI.GPT3.Interfaces;
using Shared.Share;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGptController : ControllerBase
    {
        public async Task<IActionResult> AskGpt(string query)
        {
            var message = new Message();
            message.Query = query;
            return Ok();
        }
    }
}
