using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartRent.Models;

[Index("Email", Name = "UQ__Users__A9D105346EA3D119", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(20)]
    public string? Phone { get; set; }

    [StringLength(20)]
    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AiSearchLog> AiSearchLogs { get; set; } = new List<AiSearchLog>();

    [InverseProperty("Owner")]
    public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();

    [InverseProperty("Author")]
    public virtual ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

    [InverseProperty("Customer")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("Author")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
