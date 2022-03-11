using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(mvc_identity.Areas.Identity.IdentityHostingStartup))]
namespace mvc_identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}