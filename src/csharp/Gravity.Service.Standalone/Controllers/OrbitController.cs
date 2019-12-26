/*
 * CHANGE LOG
 * 
 * 2019-01-20
 *    - modify: improve XML comments
 */
using Gravity.Services.Comet;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.DataContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Gravity.Services.Standalone.Internal.Controllers
{
    [Route("api/[controller]")]
    public class OrbitController : Controller
    {
        // POST api/Orbit
        /// <summary>
        /// runs a web-automation sequence
        /// </summary>
        /// <param name="automation">web-automation sequence to run</param>
        /// <returns>web-automation response information including extracted data</returns>
        [HttpPost]
        public async Task<IActionResult> WebAutomation([FromBody]WebAutomation automation)
        {
            var types = Utilities.GetTypes();

            // run async automation execution
            try
            {
                var results = await new Orbit(types).RunAutomationAsync(automation).ConfigureAwait(false);

                // return response as JSON
                return Json(results, Utilities.GetJsonSettings());
            }
#pragma warning disable CA1031
            catch(Exception e)
            {
                // setup conditions
                var isCredException = e.GetType() == typeof(InvalidCredentialException);
                var isInner = e.InnerException != null && e.InnerException.GetType() == typeof(InvalidCredentialException);

                // error 500
                if (!isInner && !isCredException)
                {
                    return StatusCode(500, e.Message);
                }

                // error 400
                return (!isCredException && isInner)
                    ? StatusCode(401, e.InnerException.Message)
                    : StatusCode(401, e.Message);
            }
#pragma warning restore
        }

        // GET api/Orbit
        /// <summary>
        /// gets the current service state
        /// </summary>
        /// <returns>service status information</returns>
        [HttpGet]
        public IActionResult Status() => Json(Componentes.Utilities.GetOrbitStatus(true));
    }
}