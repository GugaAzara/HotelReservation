using HotelReservation.Areas.Identity.Data;
using HotelReservation.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

	protected override void ConfigureConventions(ModelConfigurationBuilder builder)
	{
		builder.Properties<DateOnly>()
			.HaveConversion<DateOnlyConverter>()
			.HaveColumnType("date");
	}

	/// <summary>
	/// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
	/// </summary>
	public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
	{
		/// <summary>
		/// Creates a new instance of this converter.
		/// </summary>
		public DateOnlyConverter() : base(
				d => d.ToDateTime(TimeOnly.MinValue),
				d => DateOnly.FromDateTime(d))
		{ }
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
