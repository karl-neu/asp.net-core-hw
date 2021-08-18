using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
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

        //https://localhost:5001/WeatherForecast/123/49.99/1.234/1.345/12345

        [HttpGet]
        [Route("{id:int}" +
            "/{price:decimal}" +
            "/{weightDouble:double}" +
            "/{weightfloat:float}" +
            "/{ticksLong:long}")]
        public IEnumerable<WeatherForecast> Get(
            int id,
            decimal price,
            double weightDouble,
            float weightfloat,
            long ticksLong)
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // https://localhost:5001/WeatherForecast/19/91/91

        [HttpGet]
        [Route("{ageMin:min(18)}" +
            "/{ageMax:max(120)}" +
            "/{ageRange:range(18,120)}")]
        public IEnumerable<WeatherForecast> Get(
            int ageMin,
            int ageMax,
            int ageRange)
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // https://localhost:5001/WeatherForecast/Rick/MyFile/somefile.txt/somefile.txt/Rick

        [HttpGet]
        [Route("{usernameMinLength:minlength(4)}" +
            "/{filenameMaxLength:maxlength(8)}" +
            "/{filenameLength:length(12)}" +
            "/{filenameLengthRange:length(8,16)}" +
            "/{nameAlpha:alpha}")]
        public IEnumerable<WeatherForecast> Get(
            string usernameMinLength,
            string filenameMaxLength,
            string filenameLength,
            string filenameLengthRange,
            string nameAlpha)
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // https://localhost:5001/WeatherForecast/false/2021-08-19T18%3A25%3A43.511Z/CD2C1638-1638-72D5-1638-DEADBEEF1638/Rick

        [HttpGet]
        [Route("{active:bool}" +
            "/{dob:datetime}" +
            "/{id:guid}" +
            "/{name:required}")]
        public IEnumerable<WeatherForecast> Get(
            bool active,
            DateTime dob,
            Guid id,
            string name)
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // https://localhost:5001/WeatherForecast/123-45-6789

        [HttpGet]
        [Route("{ssn:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}")]
        public IEnumerable<WeatherForecast> Get(string ssn)
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // https://localhost:5001/WeatherForecast/2.5

        [HttpGet]
        [Route("{cust:customParam}")]
        public IEnumerable<WeatherForecast> Get(double cust)
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}