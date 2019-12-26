using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Standalone.Internal.Setup;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace Gravity.Service.Standalone
{
    internal static class Program
    {
        private static int port;
        private static string address;

        public static void Main(string[] args)
        {
            GetArgs(args);

            // display on screen
            Trace.TraceInformation($"web API listening on - http://{address}:{port}/api/orbit");
            Trace.TraceInformation($"knowledge base API listening on - http://{address}:{port}/api/kb");
            Trace.TraceInformation("[OrbitService] opened");

            // start host
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost
            .CreateDefaultBuilder(args)
            .UseUrls($"http://+:{port}/")
            .UseStartup<OrbitStartup>();

        private static void GetArgs(string[] args)
        {
            var factory = new CliFactory(string.Join(' ', args));
            var argument = factory.Parse();

            // set port
            if (!argument.ContainsKey("port"))
            {
                argument.Add("port", "0");
            }
            int.TryParse(argument["port"], out int portOut);
            port = portOut == 0 ? 1313 : portOut;

            // set address
            address = Utilities.GetLocalEndpoint();
        }
    }
}
