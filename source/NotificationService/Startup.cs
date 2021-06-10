using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationService
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseDeveloperExceptionPage();
            application.UseHsts();
            application.UseHttpsRedirection();
            application.UseRouting();
            application.UseResponseCompression();
            application.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_configuration.Get<AppSettings>());
            services.AddSingleton<IEmailService, EmailService>();
            services.AddResponseCompression();
            services.AddControllers();
        }
    }
}
