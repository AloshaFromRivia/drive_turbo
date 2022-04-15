using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SomeUsualShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) => 
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                .UseDefaultServiceProvider(options 
                    => options.ValidateScopes = false)
                .Build();
    }
}