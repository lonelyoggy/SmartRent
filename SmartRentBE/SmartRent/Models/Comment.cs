using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartRent.Models;

[Index("AuthorId", Name = "IX_Comments_AuthorID")]
[Index("PostId", Name = "IX_Comments_PostID")]
public partial class Comment
{
    [Key]
    [Column("CommentID")]
    public int CommentId { get; set; }

    [Column("PostID")]
    public int PostId { get; set; }

    [Column("AuthorID")]
    public int AuthorId { get; set; }

    public string Content { get; set; } = null!;

    [Column("RoomSuggestionID")]
    public int? RoomSuggestionId { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("Comments")]
    public virtual User Author { get; set; } = null!;

    [ForeignKey("PostId")]
    [InverseProperty("Comments")]
    public virtual BlogPost Post { get; set; } = null!;

    [ForeignKey("RoomSuggestionId")]
    [InverseProperty("Comments")]
    public virtual Room? RoomSuggestion { get; set; }
}
