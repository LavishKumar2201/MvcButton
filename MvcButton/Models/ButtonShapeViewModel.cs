using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcButton.Models
{
    public class ButtonShapeViewModel
    {
        public List<Button> Buttons { get; set; }
        public SelectList Shape { get; set; }
        public string ButtonShape { get; set; }
        public string SearchString { get; set; }
    }
}
