using System;
using System.ComponentModel.DataAnnotations;

namespace efAkquisition
{
    public class AnbieterMetadata
    {
        [Display(Name = "Firma")]
        public string Kürzel;

        [Display(Name = "akt. Festival")]
        public Boolean AnbieterAF;
    }
}
