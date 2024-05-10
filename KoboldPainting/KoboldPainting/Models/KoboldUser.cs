using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

[Table("KoboldUser")]
public partial class KoboldUser
{
    [Key]
    public int Id { get; set; }

    [Column("AspNetUserID")]
    [StringLength(500)]
    public string? AspNetUserId { get; set; }

    [StringLength(64)]
    public string? FirstName { get; set; }

    [StringLength(64)]
    public string? LastName { get; set; }

    [InverseProperty("KoboldUser")]
    public virtual ICollection<OwnedPaint> OwnedPaints { get; set; } = new List<OwnedPaint>();

    [InverseProperty("KoboldUser")]
    public virtual ICollection<PaintRecipe> PaintRecipes { get; set; } = new List<PaintRecipe>();

    [InverseProperty("KoboldUser")]
    public virtual ICollection<RefillPaint> RefillPaints { get; set; } = new List<RefillPaint>();

    [InverseProperty("KoboldUser")]
    public virtual ICollection<WantedPaint> WantedPaints { get; set; } = new List<WantedPaint>();
}
