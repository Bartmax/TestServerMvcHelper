using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace TestServerMvcHelper
{
    public static class WebHostBuilderExtensions {

        private static readonly string DefaultRelativePath = Path.Combine("..", "..", "src");

        public static WebHostBuilder UseApplicationPath(this WebHostBuilder builder, string applicationName) {
            return UseApplicationPath(builder, applicationName, Path.Combine(DefaultRelativePath, applicationName));
        }
        public static WebHostBuilder UseApplicationPath(this WebHostBuilder builder, string applicationName, string appBasePath) {
            var originalEnvironment = GetOriginalApplicationEnvironment();
            
            var environment = new MvcTestApplicationEnvironment(originalEnvironment, applicationName, Path.GetFullPath(appBasePath));
            return UseApplicationEnvironment(builder, environment);
        }

        private static WebHostBuilder UseApplicationEnvironment(WebHostBuilder builder, IApplicationEnvironment environment) {
            builder.UseServices(s => s.AddInstance(environment));
            return builder;
        }

        private static IApplicationEnvironment GetOriginalApplicationEnvironment() {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var originalEnvironment = provider?.GetRequiredService<IApplicationEnvironment>();
            return originalEnvironment;
        }

    }
}
