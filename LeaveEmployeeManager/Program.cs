
using LeaveEmployeeManager.Data;
using LeaveEmployeeManager.Models;
using LeaveEmployeeManager.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);






// Add services to the container.
builder.Services.AddRazorPages().AddMvcOptions(o => o.Filters.Add(new AuthorizeFilter()));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("name=DefaultConnection"));


//Set up Identity Core
builder.Services.AddDefaultIdentity<User>(options =>
{
    //super save password options XD
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

    options.SignIn.RequireConfirmedAccount = true;
    
}).AddEntityFrameworkStores<ApplicationDbContext>();

//Implement Email Func
builder.Services.AddTransient<IEmailSender>(service => new EmailSender("localhost",25,"no-reply@whatHaveIDone.de"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
