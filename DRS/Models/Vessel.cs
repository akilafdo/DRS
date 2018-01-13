using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DRS.Models
{
    public class Vessel
    {
        public Vessel()
        {
            this.d_detail = new HashSet<DistressViewModel>();
            this.licences = new HashSet<Licence>();
            this.vessel_owner_ref = new HashSet<VesselOwnerRef>();
        }
        public int vessel_id { get; set; }
        [Display(Name ="Vessel No")]
        [Required(ErrorMessage = "Vessel No is Required")]
        public string vessel_no { get; set; }
        [Display(Name = "Application Type")]
        [Required(ErrorMessage = "Application Type should be selected")]
        public int vessel_pending_approval { get; set; }
        [Display(Name = "Vessel Name")]
        public string vessel_name { get; set; }
        [Display(Name = "Vessel Color")]
        public string vessel_color { get; set; }
        [Display(Name = "Vessel Length Overall")]
        public string vessel_loa { get; set; }
        //common data
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime vessel_created_date { get; set; }
        [Display(Name = "Created By")]
        public string vessel_created_by { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public DateTime vessel_last_modified_date { get; set; }
        [Display(Name = "Last Modified By")]
        public string vessel_last_modified_by { get; set; }
        public int vessel_status { get; set; }
        [Display(Name = "Registration Code")]
        [Required(ErrorMessage = "Registration Code should be Selected")]
        public int registration_id { get; set; }
        [Display(Name = "District Code")]
        [Required(ErrorMessage = "District Code should be Selected")]
        public int district_id { get; set; }

        public virtual ICollection<DistressViewModel> d_detail { get; set; }
        public virtual District district { get; set; }
        public virtual ICollection<Licence> licences { get; set; }
        public virtual Registration registration { get; set; }
        public virtual ICollection<VesselOwnerRef> vessel_owner_ref { get; set; }
    }
}