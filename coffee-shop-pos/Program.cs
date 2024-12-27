using coffee_shop_pos;
using coffee_shop_pos.Model;

var context = new ShopContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup();

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.ConfigureApp(app);

app.Run();
