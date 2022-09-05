using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace EShop.Product.Configuration
{
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Configure Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="hostingEnvironment"></param>
        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            services.AddSwaggerGen( 
                opt =>
                {
                    opt.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "1.0",
                        Title = $"Product API ({hostingEnvironment.EnvironmentName}) v1",
                        Description = "This is the Product API",
                        Contact = new OpenApiContact
                        {
                            Name = "Product Technical Support",
                            Email = "support@eshop.com",
                            Url = new Uri("https://www.eshop.com")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Product",
                            Url = new Uri("https://www.eshop.com")
                        }
                    });

                    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description =
                            "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        Type = SecuritySchemeType.OAuth2,
                        Scheme = "Bearer",
                        Flows = new OpenApiOAuthFlows
                        {
                            AuthorizationCode = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{configuration["AzureAd:TenantId"]}/oauth2/v2.0/authorize"),
                                TokenUrl = new Uri($"https://login.microsoftonline.com/{configuration["AzureAd:TenantId"]}/oauth2/v2.0/token"),
                                //Scopes = new Dictionary<string, string>()
                                //{
                                //    {$"api://{configuration["AzureAd:ClientId"]}/.default", "access_as_user"}
                                //}
                            }
                        }
                    });

                    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Name = "Authorization"
                            },
                            new List<string>(){ "access_as_user" }

                        }
                    });
                    
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(baseDirectory, xmlFile);
                    opt.IncludeXmlComments(xmlPath);
                }
            );
        }

        /// <summary>
        /// Configure SwaggerUI
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        public static void ConfigureSwaggerUI(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwaggerUI(opt =>
            {
                opt.OAuthClientId(configuration["AzureAd:UIClientId"]);
                opt.OAuthScopes($"api://{configuration["AzureAd:ClientId"]}/.default"); // Always send the api scope to retrieve permissions granted to API
                opt.OAuthUsePkce();
                opt.ConfigObject.DocExpansion = DocExpansion.None; // Default all items on the Swagger page to start collapsed
            });
        }
    }
}
