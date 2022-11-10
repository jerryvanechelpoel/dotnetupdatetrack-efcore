using IR.DogAndCo.Api;
using Microsoft.EntityFrameworkCore;

var app = ConfigureServices(args);

ConfigureApp(app);

app.Run();

static WebApplication ConfigureServices(string[] args)
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    ConfigureEFCore(builder);

    var app = builder.Build();

    return app;
}

static void ConfigureEFCore(WebApplicationBuilder builder)
{
    string connectionString = builder.Configuration.GetConnectionString("DogAndCoDbContext");

    Action<DbContextOptionsBuilder> contextOptions = options =>
    {
        options.UseSqlServer(connectionString);
    };

    builder.Services.AddDbContext<DogAndCoDbContext>(contextOptions);

    //builder.Services.AddDbContextPool<DogAndCoDbContext>(contextOptions);

    //builder.Services.AddDbContextFactory<DogAndCoDbContext>(contextOptions);
}

static void ConfigureApp(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}