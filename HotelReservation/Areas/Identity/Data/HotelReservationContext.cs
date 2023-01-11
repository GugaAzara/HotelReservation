using HotelReservation.Areas.Identity.Data;
using HotelReservation.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Data;

public class HotelReservationContext : IdentityDbContext<HotelReservationUser>
{
    public DbSet<Customer> Customers { get; set; }
	public DbSet<Room> Rooms { get; set; }
	public DbSet<Reservation> Reservations { get; set; }

	public HotelReservationContext(DbContextOptions<HotelReservationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new CustomerConfiguration());
		builder.ApplyConfiguration(new RoomConfiguration());
        builder.ApplyConfiguration(new ReservationConfiguration());
	}
}
