using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LocalizationSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddLocalization(o =>
            {
                // We will put our translations in a folder called Resources
                o.ResourcesPath = "Resources";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en"),
                new CultureInfo("ar"),
            };

            
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                //The middleware adds 3 providers for the request culture by default:
                //    QueryStringRequestCultureProvider: Gets the culture from query string values
                //    CookieRequestCultureProvider: Gets the culture from a cookie
                //    AcceptLanguageHeaderRequestCultureProvider: Gets the culture from the Accept-Language request header

                // This is the fallback that is used if we can't figure out which one should be used
                DefaultRequestCulture = new RequestCulture("en"),

                // The cultures we wish to support
                SupportedCultures = supportedCultures, // used for number and date formats etc
                SupportedUICultures = supportedCultures // used for looking up translations from resource files.
            });

            // below will add support to lang in URL (/ar-SA/..)

            app.UseMvc();
        }
    }
}
