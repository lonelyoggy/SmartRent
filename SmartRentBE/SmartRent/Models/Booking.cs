using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartRent.Models;

[Index("CustomerId", Name = "IX_Bookings_CustomerID")]
[Index("RoomId", Name = "IX_Bookings_RoomID")]
public partial class Booking
{
    [Key]
    [Column("BookingID")]
    public int BookingId { get; set; }

    [Column("RoomID")]
    public int RoomId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    [Column(TypeName = "numeric(20, 3)")]
    public decimal? Commission { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Bookings")]
    public virtual User Customer { get; set; } = null!;

    [InverseProperty("Booking")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("RoomId")]
    [InverseProperty("Bookings")]
    public virtual Room Room { get; set; } = null!;
}
