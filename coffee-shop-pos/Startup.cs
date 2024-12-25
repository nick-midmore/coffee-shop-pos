using coffee_shop_pos.Controllers;
using coffee_shop_pos.Model;
using Microsoft.EntityFrameworkCore;

namespace coffee_shop_pos;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ShopContext>(opts =>
            opts.UseSqlite());
        services.AddMvc();
        services.AddScoped<ProductController>();
    }
}
