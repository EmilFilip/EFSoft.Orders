var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationConnectionString");

    builder.Configuration.AddAzureAppConfiguration(options =>
    {
        options.Connect(appConfigurationConnectionString)
                .ConfigureRefresh(refresh =>
                {
                    refresh.Register("Settings:Sentinel", refreshAll: true).SetCacheExpiration(new TimeSpan(0, 1, 0));
                });
    });
}

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Orders Microservice", Version = "v1" });
});

builder.Services.RegisterLocalServices(builder.Configuration);

var app = builder.Build();

app.MapCustomerEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Microservice V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
