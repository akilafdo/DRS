using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DRS.Models
{
    public class RadioStation
    {
        public RadioStation()
        {
            this.d_detail = new HashSet<DistressViewModel>();
            this.users = new HashSet<User>();
        }
        public int mcs_id { get; set; }
        [Display(Name = "MCS Callsign")]
        [Required(ErrorMessage = "MCS Callsign is Required")]
        public string mcs_callsign { get; set; }
        [Display(Name = "MCS Center Location")]
        [Required(ErrorMessage = "MCS Center Location is Required")]
        public string mcs_location { get; set; }
        [Display(Name = "Current Radio Type")]
        [Required(ErrorMessage = "Current Radio Type is Required")]
        public string mcs_radio_equipment { get; set; }
        [Display(Name = "Radio placed Date")]
        [Required(ErrorMessage = "Radio placed Date is Required")]
        [DataType(DataType.Date)]
        public DateTime mcs_radio_equipment_place_date { get; set; }
        //common data
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime mcs_created_date { get; set; }
        [Display(Name = "Created By")]
        public string mcs_created_by { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public DateTime mcs_last_modified_date { get; set; }
        [Display(Name = "Last Modified By")]
        public string mcs_last_modified_by { get; set; }
        public int mcs_status { get; set; }

        public virtual ICollection<DistressViewModel> d_detail { get; set; }
        public virtual ICollection<User> users { get; set; }
    }
}