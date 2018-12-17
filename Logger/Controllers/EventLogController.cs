using Logger.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Logger.Controllers
{
    public class EventLogController : Controller
    {
        private readonly ILogger _logger;

        public EventLogController(ILogger<EventLogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("v1/getvaluebyurl/{id:int}")]
        public IActionResult GetValueByUrl(string id)
        {
            try
            {
                _logger.Log(LogLevel.Information, $"Request url: { id }");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Error: { ex.ToString() }");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("v1/getvaluebycommand")]
        public IActionResult GetById([FromBody]EventLogDto eventLogDto)
        {
            try
            {
                _logger.Log(LogLevel.Information, $"Request body: { JsonConvert.SerializeObject(eventLogDto) }");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Error: { ex.ToString() }");
                return BadRequest();
            }
        }
    }
}