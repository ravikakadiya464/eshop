using EShop.ApiGateway.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Ocelot.json");
builder.Services.ConfigureAuthentication(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOcelot();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerForOcelotUI(opt =>
{
    opt.OAuthClientId(builder.Configuration["AzureAd:UIClientId"]);
    opt.OAuthScopes($"api://{builder.Configuration["AzureAd:ClientId"]}/.default"); // Always send the api scope to retrieve permissions granted to API
    opt.OAuthUsePkce();
});

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseOcelot().Wait();

app.Run();