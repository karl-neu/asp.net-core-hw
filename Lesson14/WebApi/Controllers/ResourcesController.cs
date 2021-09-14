using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourcesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ResourcesController> _logger;

        public ResourcesController(ILogger<ResourcesController> logger)
        {
            _logger = logger;
        }

        // https://localhost:5001/WeatherForecast/Get           //access only for admin role

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // https://localhost:5001/WeatherForecast/Get2          //access only for viewer role

        [Authorize(Roles = "viewer")]
        [HttpGet]
        [Route("[action]")]
        public WeatherForecast Get2()
        {
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = -20,
                Summary = Summaries[1]
            };
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = "vieweronlyWithDescriptionlMinLength3")]
        public WeatherForecast Get3()
        {
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = -20,
                Summary = Summaries[1]
            };
        }
    }
}