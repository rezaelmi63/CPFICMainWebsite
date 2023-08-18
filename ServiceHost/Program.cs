using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceHost;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using WbsiteManagement.Configuration;
using Websitemanagement.Infrastructure.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("CPFICmainWebsiteDB");

//var connectionString = builder.Services.AddDbContext<WebsiteContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CPFICmainWebsiteDB")));

WebsitemanagementBootstrapper.Configure(builder.Services, connectionString);
AccountManagementBootstrapper.Configure(builder.Services, connectionString);


builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();


//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    options.CheckConsentNeeded = context => false;
//    options.MinimumSameSitePolicy = SameSiteMode.Lax;
//});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
//    {
//        o.LoginPath = new PathString("/Account");
//        o.LogoutPath = new PathString("/Account");
//        o.AccessDeniedPath = new PathString("/AccessDenied");
//    });


//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminArea",
//        builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ContentUploader }));

//    options.AddPolicy("Account",
//        builder => builder.RequireRole(new List<string> { Roles.Administrator }));
//});

//builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
//    builder
//        .WithOrigins("https://localhost:5002")
//        .AllowAnyHeader()
//        .AllowAnyMethod()));

//builder.Services
//    .AddRazorPages()
//    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
//    .AddRazorPagesOptions(options =>
//    {
//        options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
//        options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
//    });


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

if (builder.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseDeveloperExceptionPage();
	//app.UseExceptionHandler("/Error");
	app.UseHsts();
}


app.UseAuthentication();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();



