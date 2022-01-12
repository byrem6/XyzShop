using CustomerServices.Context;
using CustomerServices.Contracts.CommandHandler;
using CustomerServices.Contracts.QueryHandlers;
using CustomerServices.Handlers.CommandHandlers;
using CustomerServices.Handlers.QueryHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CustomerServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors();

            services.AddDbContext<CustomerServicesDbContext>(options => options.UseSqlServer(@"data source=(localdb)\MSSQLLocalDB;initial catalog=XyzShopCustomerDB;persist security info=True;user id=sa;password=000;"));

            services.AddScoped<ICustomerCommandHandler, CustomerCommandHandler>();
            services.AddScoped<ICustomerQueryHandler, CustomerQueryHandler>();

            services.AddMemoryCache();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Xyz Shop Customer Services", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerServices v1"));
            }

            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
