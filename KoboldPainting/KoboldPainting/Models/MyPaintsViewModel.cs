using System.Collections.Generic;

namespace KoboldPainting.Models
{
    public class MyPaintsViewModel
    {
        public List<Paint> OwnedPaints { get; set; } = new List<Paint>();
        public List<Paint> WantedPaints { get; set; } = new List<Paint>();
        public List<Paint> RefillPaints { get; set; } = new List<Paint>();
    }

}