using Alloy_Vanilla.Extensions;
using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.ContentApi.Cms.Internal;
using EPiServer.ContentApi.Core.Configuration;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Newtonsoft.Json;

namespace Alloy_Vanilla;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;

    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddAlloy()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>();

        // Required by Wangkanai.Detection
        services.AddDetection();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddContentDeliveryApi(o =>
        {
            o.SiteDefinitionApiEnabled = false;
            o.DisableScopeValidation = true;
        });

        // Content API Options
        services.Configure<ContentApiOptions>(o =>
        {
            o.ExpandedBehavior = ExpandedLanguageBehavior.RequestedLanguage;
            o.FlattenPropertyModel = true;
            o.EnablePreviewFeatures = true;
            o.EnablePreviewMode = true;
            o.ForceAbsolute = false;
            o.ValidateTemplateForContentUrl = false;
            o.IncludeEmptyContentProperties = false;
            o.IncludeMasterLanguage = false;
        });

        // Ignore properties which return null values
        services.ConfigureContentDeliveryApiSerializer(o =>
            o.NullValueHandling = NullValueHandling.Ignore);

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Required by Wangkanai.Detection
        app.UseDetection();
        app.UseSession();

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapContent();
        });
    }
}
