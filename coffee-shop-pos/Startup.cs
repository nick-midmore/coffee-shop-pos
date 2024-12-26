using coffee_shop_pos.Controllers;
using coffee_shop_pos.Model;
using Microsoft.EntityFrameworkCore;

namespace coffee_shop_pos;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ShopContext>();
        services.AddScoped<ProductController>();
        services.AddScoped<ProductModel>();
        services.AddMvc();
        services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();
    }

    public void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}   
