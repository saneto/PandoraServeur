using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServeurPandora.Models;
using Microsoft.Data.Entity;
using ServeurPandora.Service;
using ServeurPandora.IService;
using ServeurPandora.ModelVersionPro;
using ServeurPandora.IservicePRo;
using ServeurPandora.ServicePro;

namespace ServeurPandora
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("Dataconfig.json");

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build().ReloadOnChanged("appsettings.json");
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services. 
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddCors();
            services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<DataModel>(options =>
                   
                        options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"])
                    );
           
            services.AddMvc();

            services.AddTransient<IAcces, AccesService>();
            //PArtie Client Normal 
            services.AddInstance<IAcces>(new AccesService());
            services.AddInstance<IHistoriqueAcces>(new HistoriqueAccesService());
            services.AddInstance<IHistoriqueCompte>(new HistoriqueCompteService());
            services.AddInstance<IInscription>(new Inscription());
            services.AddInstance<ILogin>(new Login());


            //Partie Pro

            services.AddInstance<IAccesServicePro>(new AccesServicePro());
            services.AddInstance<IHistoriqueAccesServicePro>(new HistoriqueAccesServicePro());
            services.AddInstance<IHistoriqueCompteServicePro>(new HistoriqueCompteServicePro());
            services.AddInstance<IInscriptionServicePro>(new InscriptionServicePRo());
            services.AddInstance<ILoginServicePro>(new LoginServicePro());
            /*  var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNet5.NewDb;Trusted_Connection=True;";

              services.AddEntityFramework()
                  .AddDbContext<DataModel>(options => options.UseModel(connection))   ;*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            app.UseIISPlatformHandler();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseMvc();

            Class.Initialize(app.ApplicationServices);
        }
        
        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);

    }
}
