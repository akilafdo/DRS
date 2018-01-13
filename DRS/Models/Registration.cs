using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DRS.Models
{
    public class Registration
    {
        public Registration()
        {
            this.vessels = new HashSet<Vessel>();
        }
        public int registration_id { get; set; }
        [Display(Name ="Vessel Reg.Code")]
        [Required(ErrorMessage ="Vessel Reg.Code is Required")]
        public string registration_code { get; set; }
        [Display(Name = "Reg.Code Description")]
        [Required(ErrorMessage = "Vessel Reg.Code Description is Required")]
        public string registration_description { get; set; }
        //common data
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime registration_created_date { get; set; }
        [Display(Name = "Created By")]
        public string registration_created_by { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public DateTime registration_last_modified_date { get; set; }
        [Display(Name = "Last Modified By")]
        public string registration_last_modified_by { get; set; }
        public int registration_status { get; set; }

        public virtual ICollection<Vessel> vessels { get; set; }
    }
}