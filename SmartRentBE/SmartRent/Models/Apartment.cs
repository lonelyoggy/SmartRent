using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartRent.Models;

[Index("OwnerId", Name = "IX_Apartments_OwnerID")]
public partial class Apartment
{
    [Key]
    [Column("ApartmentID")]
    public int ApartmentId { get; set; }

    [Column("OwnerID")]
    public int OwnerId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    public string Address { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 6)")]
    public decimal? Latitude { get; set; }

    [Column(TypeName = "decimal(10, 6)")]
    public decimal? Longitude { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("OwnerId")]
    [InverseProperty("Apartments")]
    public virtual User Owner { get; set; } = null!;

    [InverseProperty("Apartment")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
