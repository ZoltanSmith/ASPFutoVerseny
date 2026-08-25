using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPFutoVerseny.Models;

public partial class Versenyzo
{
    [ScaffoldColumn(false)]
    [Key]
    public uint Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Nev { get; set; } = null!;

    [MaxLength(45)]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [Range(10,100)]
    public uint Kor { get; set; }

    [Required]
    [Range(100,1000)]
    public float Tav { get; set; }

    [Required]
    [DisplayName("Kvalifikációs idő:")]
    public TimeOnly KvalifikaciosIdo { get; set; }

    [Required]
    public bool Profi { get; set; }
}
