using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DRS.Models
{
    public class Owner
    {
        public Owner()
        {
            this.vessel_owner_ref = new HashSet<VesselOwnerRef>();
        }
        public int owner_id { get; set; }
        [Display(Name = "Owner Name")]
        [Required(ErrorMessage = "Owner Name is Required")]
        public string owner_name { get; set; }
        [Display(Name = "NIC No")]
        public string owner_nic { get; set; }
        [Display(Name = "Resident Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string owner_address { get; set; }
        [Display(Name = "Telephone No")]
        public string owner_tele { get; set; }
        //common data
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime owner_created_date { get; set; }
        [Display(Name = "Created By")]
        public string owner_created_by { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public DateTime owner_last_modified_date { get; set; }
        [Display(Name = "Last Modified By")]
        public string owner_last_modified_by { get; set; }
        public int owner_status { get; set; }

        public virtual ICollection<VesselOwnerRef> vessel_owner_ref { get; set; }
    }
}