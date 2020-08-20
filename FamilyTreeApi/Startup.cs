using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FamilyTreeApi.Data;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.Data.Repository;
using FamilyTreeApi.Helpers;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace FamilyTreeApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //inject appsetting class
            services.Configure<AppSettings>(Configuration.GetSection("AppSetting"));

            //config identity
            services.AddIdentity<User, Role>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<FamilyTreeContext>().AddDefaultTokenProviders();

            //config context
            services.AddDbContext<FamilyTreeContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("FamilyTreeConnection"))
             );

            //config  jwt token
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSetting:SecritKey").Value)),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true
                   };
               });

            //config mvc
            services.AddMvc(opt =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            //services.AddCors();

            string[] domains =
            {
               "http://yasserproject-001-site1.btempurl.com",
               "http://localhost:4200",
               "http://localhost:4201"
            };

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(domains)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddAutoMapper();

            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IUtitlities, Utitlities>();
            services.AddTransient<IDefinitionLineageRepo, DefinitionLineageRepo>();
            services.AddTransient<IFamilyCharactersRepo, FamilyCharactersRepo>();
            services.AddTransient<IGeneralSettings, GeneralSettings>();
            services.AddTransient<IFamilyRepo, FamilyRepo>();
            services.AddTransient<IBlogRepo, BlogRepo>();
            services.AddTransient<IBlogCommentRepo, BlogCommentRepo>();
            services.AddTransient<INewsRepo, NewsRepo>();
            services.AddTransient<INewsCommentRepo, NewsCommentRepo>();
            services.AddTransient<ITermsRepo, TermsRepo>();
            services.AddTransient<IWifeRepo, WifeRepo>();
            services.AddTransient<IUploaderRepo, UploaderRepo>();
            services.AddTransient<INewsImageRepo, NewsImageRepo>();
            services.AddTransient<IHomeRepo, HomeRepo>();
            //services.AddRouting(options => options.LowercaseUrls = true);

            //Configuration signalR
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseStaticFiles();

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
                //if (ctx.Response.StatusCode == 200)
                //{
                //    ctx.Response.ContentLength = 0;
                //}
            });

            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());            
            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseSignalR(route =>
            {
                route.MapHub<SignalService>("/signalService");
            });
            
            app.UseMvc();
        }
    }

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
