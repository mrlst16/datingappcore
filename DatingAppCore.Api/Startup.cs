using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using CommonCore.Models.Authentication;
using DatingAppCore.Api.MiddleWare;
using DatingAppCore.Api.ServiceRegistration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson.Serialization;

namespace DatingAppCore.Api
{

    public static class JwtTokenMiddleware
    {
        public static IApplicationBuilder UseJwtTokenMiddleware(
          this IApplicationBuilder app,
          string schema = "Bearer")
        {
            return app.Use((async (ctx, next) =>
            {
                IIdentity identity = ctx.User.Identity;
                if ((identity != null ? (!identity.IsAuthenticated ? 1 : 0) : 1) != 0)
                {
                    AuthenticateResult authenticateResult = await ctx.AuthenticateAsync(schema);
                    if (authenticateResult.Succeeded && authenticateResult.Principal != null)
                        ctx.User = authenticateResult.Principal;
                }
                await next();
            }));
        }
    }

    public class JwtIdentityUser : IdentityUser
    {

    }
    public class Startup
    {
        private ILogger<Startup> _logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            BsonClassMap.RegisterClassMap<PasswordRecord>(x =>
            {
                x.AutoMap();
                x.SetIgnoreExtraElements(true);
            });

            services.RegisterServices();
            services.RegisterLoaders();
            services.RegisterContexts(Configuration);
            services.RegisterValidators();
            services.RegisterLoggers();

            services.AddTransient<IAuthorizationHandler, JWTAuthorizationHandler>();

            services.AddTransient<IConfiguration>(x => Configuration);

            services.AddIdentity<JwtIdentityUser, IdentityUser>(setupAction =>
            {
            }).AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.MapInboundClaims = true;
                var issuer = Configuration.GetValue<string>("Jwt:Issuer");
                var key = Configuration.GetValue<string>("Jwt:Key");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    NameClaimType = ClaimTypes.Name,
                    TokenReader = (token, parameters) =>
                    {
                        var result = new JwtSecurityToken();
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        result = handler.ReadJwtToken(token);
                        return result;
                    }
                };
            });
            services.AddAuthorization(x =>
            {
                x.AddPolicy(JwtBearerDefaults.AuthenticationScheme, y =>
                {
                    y.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    y.AddRequirements(new JWTAuthorizationRequirement());
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            _logger = logger;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseJwtTokenMiddleware();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    _logger.LogInformation($"404 :{context.Request.Host}/{context.Request.Path}");
                }

                if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    _logger.LogInformation($"403 :{context.Request.Host}/{context.Request.Path}");
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
