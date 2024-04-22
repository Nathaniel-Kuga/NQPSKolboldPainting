using KoboldPainting.Models;

namespace KoboldPainting.Models;

public class PaintsViewModel
{
    public Paint Paint { get; set; }
    public Company Company { get; set; }
    public PaintType PaintType { get; set; }
    // public IEnumerable<Paint> Paints { get; set; }
    // public IEnumerable<Company> Companies { get; set; }
    // public IEnumerable<PaintType> PaintTypes { get; set; }
}