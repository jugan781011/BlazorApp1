using BlazorApp1;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Localization;
using Syncfusion.Blazor;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
string uri = builder.Configuration.GetValue<string>("MetaAPI");
builder.Services.AddSyncfusionBlazor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddSignalR(p => {
    p.MaximumReceiveMessageSize = 102400000;
});
#region Service
builder.Services.AddHttpClient<Itb_UserMemberService, tb_UserMemberService>("meta", c =>
{
    c.BaseAddress = new Uri(uri);
});
#endregion

#region Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
        new CultureInfo("zh-TW")
    };
    options.DefaultRequestCulture = new RequestCulture("zh-TW");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRequestLocalization("zh-TW");
app.UseStaticFiles();

app.UseRouting();

#region 指定要使用 Cookie & 使用者認證的中介軟體
app.UseAuthentication();
app.UseAuthorization();
#endregion


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
