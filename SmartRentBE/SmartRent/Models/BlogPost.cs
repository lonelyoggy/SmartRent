using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartRent.Models;

[Index("AuthorId", Name = "IX_BlogPosts_AuthorID")]
public partial class BlogPost
{
    [Key]
    [Column("PostID")]
    public int PostId { get; set; }

    [Column("AuthorID")]
    public int AuthorId { get; set; }

    [StringLength(255)]
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("BlogPosts")]
    public virtual User Author { get; set; } = null!;

    [InverseProperty("Post")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
