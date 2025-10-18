using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartRent.Models;

[Index("ApartmentId", Name = "IX_Rooms_ApartmentID")]
public partial class Room
{
    [Key]
    [Column("RoomID")]
    public int RoomId { get; set; }

    [Column("ApartmentID")]
    public int ApartmentId { get; set; }

    [StringLength(150)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Area { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public int? NumBedrooms { get; set; }

    public int? NumBathrooms { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey("ApartmentId")]
    [InverseProperty("Rooms")]
    public virtual Apartment Apartment { get; set; } = null!;

    [InverseProperty("Room")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("RoomSuggestion")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [InverseProperty("Room")]
    public virtual ICollection<RoomImage> RoomImages { get; set; } = new List<RoomImage>();
}
