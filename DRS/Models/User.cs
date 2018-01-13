using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DRS.Models
{
    public class User
    {
        public int user_id { get; set; }
        [Display(Name = "Officer Name")]
        [Required(ErrorMessage = "Officer Name is Required")]
        public string user_name { get; set; }
        [Display(Name = "NIC No")]
        [Required(ErrorMessage = "NIC No is Required")]
        public string user_nic { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string user_address { get; set; }
        [Display(Name = "Telephone No")]
        [Required(ErrorMessage = "Telephone No is Required")]
        public string user_tele { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is Required")]
        public string user_username { get; set; }
        [Display(Name = "MCS Center")]
        [Required(ErrorMessage = "MCS Center is Required")]
        public int mcs_id { get; set; }

        //common date
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime user_created_date { get; set; }
        [Display(Name = "Created By")]
        public string user_created_by { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public DateTime user_last_modified_date { get; set; }
        [Display(Name = "Last Modified By")]
        public string user_last_modified_by { get; set; }
        public int user_status { get; set; }

        public virtual RadioStation radio_station { get; set; }
    }
}