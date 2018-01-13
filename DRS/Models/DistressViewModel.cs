using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DRS.Models;

namespace DRS.Models
{
    public class DistressViewModel
    {
        public int d_detail_id { get; set; }
        [Display(Name = "Lattitude deg:")]
        [Required(ErrorMessage = "Lattitude deg is Required")]
        public string d_detail_lkp_lat_deg { get; set; }
        [Display(Name = "Lattitude min:")]
        [Required(ErrorMessage = "Lattitude min is Required")]
        public string d_detail_lkp_lat_min { get; set; }
        [Required(ErrorMessage = "Lattitude Direction should be selected")]
        public string d_detail_lkp_lat_direction { get; set; }
        [Display(Name = "Longitude deg:")]
        [Required(ErrorMessage = "Longitude deg is Required")]
        public string d_detail_lkp_long_deg { get; set; }
        [Display(Name = "Longitude min:")]
        [Required(ErrorMessage = "Longitude min is Required")]
        public string d_detail_lkp_long_min { get; set; }
        [Required(ErrorMessage = "Longitude Direction should be selected")]
        public string d_detail_lkp_long_direction { get; set; }
        [Display(Name = "Last known position Date")]
        [Required(ErrorMessage = "Last known position Date is Required")]
        [DataType(DataType.Date)]
        public System.DateTime d_detail_lkp_date { get; set; }
        [Display(Name = "Last known position Time")]
        [Required(ErrorMessage = "Last known position Time is Required")]
        [DataType(DataType.Time)]
        public System.TimeSpan d_detail_lkp_time { get; set; }
        [Display(Name = "Vessel Communication Frequency")]
        public string d_detail_communication_freqency { get; set; }
        [Display(Name = "Nature of Distress")]
        public string d_detail_nature_of_distress { get; set; }
        [Display(Name = "No of Crew Onboard")]
        [Range(1,int.MaxValue,ErrorMessage ="No of Crew Onboard should be positive value")]
        public Nullable<int> d_detail_no_of_crew { get; set; }
        [Display(Name = "Names of Crew")]
        public string d_detail_names_of_crew { get; set; }
        [Display(Name = "Action Taken")]
        [Required(ErrorMessage = "Action Taken Field cannot be blank")]
        public string d_detail_action_taken { get; set; }
        [Display(Name = "Remarks")]
        [Required(ErrorMessage = "Remarks Field cannot be blank")]
        public string d_detail_remarks { get; set; }
        [Display(Name = "Departure Date")]
        [Required(ErrorMessage = "Departure Date is Required")]
        [DataType(DataType.Date)]
        public System.DateTime d_detail_departure_date { get; set; }
        [Display(Name = "Departure Time")]
        [Required(ErrorMessage = "Departure Time is Required")]
        [DataType(DataType.Time)]
        public System.TimeSpan d_detail_departure_time { get; set; }
        [Display(Name = "Departure Location")]
        [Required(ErrorMessage = "Departure Location is Required")]
        public string d_detail_departure_location { get; set; }

        //common data
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public System.DateTime d_detail_created_date { get; set; }
        [Display(Name = "Created By")]
        public string d_detail_created_by { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public System.DateTime d_detail_last_modified_date { get; set; }
        [Display(Name = "Last Modified By")]
        public string d_detail_last_modified_by { get; set; }
        public int d_detail_status { get; set; }

        [Required(ErrorMessage = "Vessel No is Required")]
        public int vessel_id { get; set; }
        [Required(ErrorMessage = "Distress should be Selected")]
        public int distress_id { get; set; }
        [Required(ErrorMessage = "MCS Center should be Selected")]
        public int mcs_id { get; set; }

        public virtual Distress distress { get; set; }
        public virtual RadioStation radio_station { get; set; }
        public virtual Vessel vessel { get; set; }
    }
}