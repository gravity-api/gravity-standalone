/*
 * CHANGE LOG
 * 
 * 2019-01-20
 *    - modify: improve XML comments
 */
namespace Gravity.Services.Standalone.Internal.Componentes
{
    internal static class Utilities
    {
        /// <summary>
        /// gets orbit-service status object
        /// </summary>
        /// <param name="available">flag to indicates if service is available or not</param>
        /// <returns>service status object</returns>
        public static object GetOrbitStatus(bool available) => new
        {
            Service = "OrbitService",
            Available = available,
            ServiceType = nameof(Comet)
        };
    }
}