using DemoRestAPI;
using DemoRestAPI.Brands.Repository;
using DemoRestAPI.Brands.Service;
using DemoRestAPI.Categories.Repository;
using DemoRestAPI.Categories.Service;
using DemoRestAPI.Devices;
using DemoRestAPI.Helpers;
using DemoRestAPI.Models.Repository;
using DemoRestAPI.Models.Service;
using DemoRestAPI.Products.Repository;
using DemoRestAPI.Products.Service;
using DemoRestAPI.Storages.Repository;
using DemoRestAPI.Storages.Service;
using DemoRestAPI.Users;
using DemoRestAPI.Users.Authentication;
using DemoRestAPI.Users.Repository;
using DemoRestAPI.Users.Service;
using DemoRestAPI.Warehouses.Repository;
using DemoRestAPI.Warehouses.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace AuthServer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            if (builder != null) 
            {
                builder.Services.AddControllers().AddNewtonsoftJson(options => {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGenNewtonsoftSupport();
                builder.Services.AddSwaggerGen(c =>
{
                    /*c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv6", Version = "v1" });*/

                    var securityScheme = new OpenApiSecurityScheme
                    {
                        Name = "JWT Authentication",
                        Description = "Enter your JWT token in this field",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT"
                    };

                    c.AddSecurityDefinition("Bearer", securityScheme);
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    },
                                    Scheme = "oauth2",
                                    Name = "Bearer",
                                    In = ParameterLocation.Header,

                                },
                                new List<string>()
                            }
                    });
                });

                builder.Services.AddDbContext<SqlDBContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );

                builder.Services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireDigit = true;
                }).AddEntityFrameworkStores<SqlDBContext>().AddDefaultTokenProviders();

                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.IncludeErrorDetails = true;

                    string pathKey = builder.Configuration.GetSection("Jwt:PublicKeyPath").Value;
                    string pathIssurer = builder.Configuration.GetSection("Jwt:Issuer").Value;
                    string pathAudience = builder.Configuration.GetSection("Jwt:Audience").Value;

                    RsaSecurityKey issurerSigningKey = null;

                    if (pathKey != null)
                    {
                        RsaKeyGenerator rsaKeyGenerator = new RsaKeyGenerator(builder.Configuration);
                        rsaKeyGenerator.GeneratePrivateRsaKey();

                        RSA rsaKey = RSA.Create();
                        string xmlKey = File.ReadAllText(pathKey);
                        rsaKey.FromXmlString(xmlKey);

                        issurerSigningKey = new RsaSecurityKey(rsaKey);
                    }

                    if (issurerSigningKey != null && pathIssurer != null && pathAudience != null)
                    {
                        o.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidAudience = pathAudience,
                            ValidIssuer = pathIssurer,
                            ValidateActor = false,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            RequireExpirationTime = true,
                            ValidateIssuerSigningKey = true,
                            ClockSkew = TimeSpan.Zero,
                            IssuerSigningKey = issurerSigningKey,
                        };
                    }

                    o.IncludeErrorDetails = true;
                });
                builder.Services.AddAuthorization();

                builder.Services.AddTransient<IAuthService, UserAuthService>();
                builder.Services.AddTransient<IBrandService, BrandService>();
                builder.Services.AddTransient<ICategoryService, CategoryService>();
                builder.Services.AddTransient<IModelService, ModelService>();
                builder.Services.AddTransient<IWarehouseService, WarehouseService>();
                builder.Services.AddTransient<IStorageService, StorageService>();
                builder.Services.AddTransient<IProductService, ProductService>();

                builder.Services.AddScoped<IBrandRepository, BrandRepository>();
                builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
                builder.Services.AddScoped<IModelRepository, ModelRepository>();
                builder.Services.AddScoped<IProductRepository, ProductRepository>();
                builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
                builder.Services.AddScoped<IStorageRepository, StorageRepository>();
                builder.Services.AddScoped<IUserRepository, UserRepository>();
                builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();

                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthentication();
                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
        } 
    } 
}
