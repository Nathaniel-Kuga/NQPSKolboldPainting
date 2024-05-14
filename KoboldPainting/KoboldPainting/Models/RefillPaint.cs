using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

[Table("RefillPaint")]
public partial class RefillPaint
{
    [Key]
    public int Id { get; set; }

    [Column("KoboldUserID")]
    public int? KoboldUserId { get; set; }

    [Column("PaintID")]
    public int? PaintId { get; set; }

    [ForeignKey("KoboldUserId")]
    [InverseProperty("RefillPaints")]
    public virtual KoboldUser? KoboldUser { get; set; }

    [ForeignKey("PaintId")]
    [InverseProperty("RefillPaints")]
    public virtual Paint? Paint { get; set; }
}
