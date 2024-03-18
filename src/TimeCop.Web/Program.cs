using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TimeCop.Identity;

using TimeCop.Identity.Models;
using TimeCop.TimeSheet;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IEmailSender, TimeCop.Identity.EmailSender>();
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Identity"));

});


builder.Services.AddDbContext<TimeSheetDbContext>(options =>

    {

        options.UseSqlServer(builder.Configuration.GetConnectionString("TimeSheet"));
    });





builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    //.AddDefaultUI()
    .AddSignInManager()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IBankHolidayService, BankHolidayService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithReExecute("/errors/{0}");
    app.UseExceptionHandler("/error");
}
else
{
    app.UseStatusCodePagesWithReExecute("/errors/{0}");
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
