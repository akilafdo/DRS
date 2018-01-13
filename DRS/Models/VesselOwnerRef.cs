using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DRS.Models
{
    public class VesselOwnerRef
    {
        public int vessel_owner_ref_id { get; set; }
        [Required(ErrorMessage = "Please search the valid owner or you have entered invalid owner data")]
        public int owner_id { get; set; }
        [Required(ErrorMessage = "Please search the valid vessel or you have entered invalid vessel data")]
        public int vessel_id { get; set; }

        public virtual Owner owner { get; set; }
        public virtual Vessel vessel { get; set; }
    }
}