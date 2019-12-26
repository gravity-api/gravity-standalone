/*
 * CHANGE LOG (keep only last 5 threads)
 * 
 * 2019-01-17
 *    - modify: implement get action method
 *    - modify: implement get locators method
 * 
 * 2019-01-20
 *    - modify: move out all private methods (into utilities & extensions)
 * 
 * 2019-01-27
 *    - modify: re-factor get-kb method to be generic
 *    - modify: add macros kb controller
 * 
 * 2019-01-30
 *    - modify: re-factor to fetch kb from orbit client
 */
using Gravity.Services.Comet;
using Gravity.Services.Comet.Engine.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Gravity.Services.Standalone.Controllers
{
    public class KbController : Controller
    {
        // members: state
        private readonly Orbit client;

        public KbController()
        {
            var types = Utilities.GetTypes();
            client = new Orbit(types);
        }

        // GET api/kb/actions
        [HttpGet]
        [Route("api/kb/actions")]
        public IActionResult Actions() => Json(client.Actions());

        // GET api/kb/actions/?action=someAction
        [HttpGet]
        [Route("api/kb/actions/{id}")]
        public IActionResult Actions([FromRoute] string id)
        {
            return Json(client.Actions(id));
        }

        // GET api/kb/macros
        [HttpGet]
        [Route("api/kb/macros")]
        public IActionResult Macros() => Json(client.Macros());

        // GET api/kb/macros/?macro=someAction
        [HttpGet]
        [Route("api/kb/macros/{id}")]
        public IActionResult Macros([FromRoute] string id)
        {
            return Json(client.Macros(id));
        }

        // GET api/kb/locators
        [HttpGet]
        [Route("api/kb/locators")]
        public IActionResult Locators() => Json(client.Locators());

        // GET api/kb/sources
        [HttpGet]
        [Route("api/kb/sources")]
        public IActionResult Sources() => Json(client.DataSourceTypes());

        // GET api/kb/contracts
        [HttpGet]
        [Route("api/kb/contracts")]
        public IActionResult Contracts() => Json(client.DataContracts());

        // GET api/kb/contracts/?contract=someAction
        [HttpGet]
        [Route("api/kb/contracts/{id}")]
        public IActionResult Contracts([FromRoute] string id)
        {
            return Json(client.DataContracts(id));
        }
    }
}