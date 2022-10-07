namespace GroceryShopAPI
{
    using Microsoft.OpenApi.Models;
    using GroceryShopAPI.Common;
    using GroceryShopAPI.Middleware;
    using GroceryShopAPI.Extensions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using GroceryShopAPI.Data;

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = GlobalConstants.ProjectName, Version = "v1" });
            });

            services.AddDbContext<ShopDbContext>(opts =>
            {
                opts.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.InitializeDatabase();    

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{GlobalConstants.ProjectName} v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(GlobalConstants.ClientUrl);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
