﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifaPlayers.DAOs.Clubs;
using FifaPlayers.DAOs.Leagues;
using FifaPlayers.DAOs.Players;
using FifaPlayers.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FifaPlayers
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var ty = typeof(String);

            services.AddSingleton(typeof(Procedures), typeof(Procedures));
            services.AddSingleton(typeof(LeagueDAO), typeof(ProceduresLeagueDAO));
            services.AddSingleton(typeof(ClubDAO), typeof(ProceduresClubDAO));
            services.AddSingleton(typeof(PlayerDAO), typeof(ProceduresPlayerDAO));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

   
}

public interface IDummy
{
    void Out();
}