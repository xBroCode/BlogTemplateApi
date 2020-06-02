using BroCode.BlogTemplate.DTO;
using BroCode.BlogTemplate.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace BroCode.BlogTemplate.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            DependencyResolver.ConfigureServices(services, Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Blog Template API",
                    Description = "Template for easy creation of blogs",
                    Version = "1.0.0-alpha1",
                    Contact = new OpenApiContact 
                    { 
                        Name = "Ícaro Falcão", 
                        Email = "vbsfalcao@gmail.com", 
                        Url = new Uri("https://ifalcao.live") 
                    }
                });
            });

            services.AddOptions<JwtConfig>().Bind(Configuration.GetSection("JwtConfig"));

            var secretKey = Configuration.GetSection("JwtConfig:SecretKey").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            ConfigureTokenValidation(services, signingKey);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(corsBuilder => corsBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogTemplate");
            });
        }

        private void ConfigureTokenValidation(IServiceCollection services, SymmetricSecurityKey signingKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = "BlogTemplate",
                ValidateAudience = true,
                ValidAudience = "*",
                ValidateLifetime = true
            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Audience = "*";
                    options.Authority = "*";
                    options.TokenValidationParameters = tokenValidationParameters;
                    // options.RequireHttpsMetadata = false; -> Development config
                    options.RequireHttpsMetadata = false;
                    options.Configuration = new OpenIdConnectConfiguration();
                });
        }
    }
}
