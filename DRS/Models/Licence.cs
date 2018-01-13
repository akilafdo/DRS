using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DRS.Models
{
    public class Licence
    {
        public int licence_id { get; set; }
        [Display(Name ="License Callsign")]
        [Required(ErrorMessage = "License Callsign is Required")]
        public string licence_callsign { get; set; }
        [Display(Name ="Date From")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "License Date From should be selected")]
        public DateTime licence_date_from { get; set; }
        [Display(Name ="Date To")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "License Date To should be selected")]
        public DateTime licence_date_to { get; set; }
        [Display(Name ="TRC File No")]
        [Required(ErrorMessage = "TRC File No is Required")]
        public string licence_trc_fileno { get; set; }
        //common data
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime licence_created_date { get; set; }
        [Display(Name = "Created By")]
        public string licence_created_by { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public DateTime licence_last_modified_date { get; set; }
        [Display(Name = "Last Modified By")]
        public string licence_last_modified_by { get; set; }
        public int licence_status { get; set; }


        [Display(Name ="Vessel ID")]
        [Required(ErrorMessage = "Please search the valid vessel")]
        public int vessel_id { get; set; }

        public virtual Vessel vessel { get; set; }
    }
}