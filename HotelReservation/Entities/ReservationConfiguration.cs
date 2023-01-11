using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Entities
{
	public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
	{
		public void Configure(EntityTypeBuilder<Reservation> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.Customer)
				.WithMany(c => c.Reservations)
				.HasForeignKey(c => c.CustomerId);
			builder.HasOne(r => r.Room)
				.WithMany(c => c.Reservations)
				.HasForeignKey(r => r.RoomId);
		}
	}
}
