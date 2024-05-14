using System.ComponentModel.DataAnnotations;
using KoboldPainting.Models;

namespace KoboldPainting.Models;

public class PaintsViewModel
{
    [Required(ErrorMessage = "Paint is required.")]
    public string Paint { get; set; }

    [Required(ErrorMessage = "Company is required.")]
    public int SelectedCompany { get; set; }

    [Required(ErrorMessage = "PaintType is required.")]
    public int SelectedPaintType { get; set; }

    public List<Company> Companies { get; set; } = new List<Company>();
    public List<PaintType> PaintTypes { get; set; } = new List<PaintType>();
    public string ResultMessage { get; set; } = "";
    public bool IsSuccess { get; set; } = false;
    public bool IsFormSubmitted { get; set; } = false;
    public List<Paint> Paints { get; set; } = new List<Paint>();
}
