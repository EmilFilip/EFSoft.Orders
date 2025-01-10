var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationConnectionString");

    _ = builder.Configuration.AddAzureAppConfiguration(options =>
    {
        _ = options.Connect(appConfigurationConnectionString)
                .ConfigureRefresh(refresh =>
                {
                    _ = refresh.Register("Settings:Sentinel", refreshAll: true).SetRefreshInterval(new TimeSpan(0, 1, 0));
                });
    });
}

builder.Services.AddCarter();
// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderRequestValidator>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Orders Microservice", Version = "v1" });
});

builder.Services.RegisterLocalServices(builder.Configuration);

var app = builder.Build();
app.MapCarter();

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

app.Run();
