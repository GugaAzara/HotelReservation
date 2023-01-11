using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Data;
using HotelReservation.Areas.Identity.Data;
using HotelReservation.Interfaces;
using HotelReservation.Services;
using HotelReservation.Entities;
using HotelReservation.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HotelReservationContextConnection") ?? throw new InvalidOperationException("Connection string 'HotelReservationContextConnection' not found.");

builder.Services.AddDbContext<HotelReservationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<HotelReservationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<HotelReservationContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connect Services to Interfaces
builder.Services.AddScoped<ICostumerService, CustomerService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.MapRazorPages();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Reservation}/{action=Index}/{id?}");

app.Run();
