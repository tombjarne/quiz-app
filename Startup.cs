using System;
using System.Reflection;
using Google.Protobuf;
using Lifekeys.Contexts;
using Lifekeys.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lifekeys
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
            var assembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AuthPolicy",
                    builder =>
                    {
                        // development settings
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    }
                );
            });

            services.AddDbContext<QuizContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("Database"),
                    o =>
                    {
                        o.MigrationsAssembly(assembly);
                        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                    });
            });

            services.Configure<JsonFormatter.Settings>(Configuration.GetSection("Settings"));

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            services.AddSingleton<DbService>(
                new DbService(services.BuildServiceProvider().GetService<QuizContext>())
            );

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
