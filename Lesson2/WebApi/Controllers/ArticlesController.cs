using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ILogicPublish _logicPublish;
        public ArticlesController(ILogicPublish logicPublish)
        {
            this._logicPublish = logicPublish;
        }

        [HttpGet]
        public void Get()
        {
            _logicPublish.Publish();
        }
    }
}