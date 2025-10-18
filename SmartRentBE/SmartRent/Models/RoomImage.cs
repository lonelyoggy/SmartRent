using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartRent.Models;

[Index("RoomId", Name = "IX_RoomImages_RoomID")]
public partial class RoomImage
{
    [Key]
    [Column("ImageID")]
    public int ImageId { get; set; }

    [Column("RoomID")]
    public int RoomId { get; set; }

    [StringLength(500)]
    public string ImageUrl { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("RoomImages")]
    public virtual Room Room { get; set; } = null!;
}
