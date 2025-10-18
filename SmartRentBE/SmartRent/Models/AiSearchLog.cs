using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartRent.Models;

[Table("AI_SearchLogs")]
[Index("UserId", Name = "IX_AI_SearchLogs_UserID")]
public partial class AiSearchLog
{
    [Key]
    [Column("LogID")]
    public int LogId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(500)]
    public string? SearchQuery { get; set; }

    public string? Preferences { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("AiSearchLogs")]
    public virtual User User { get; set; } = null!;
}
