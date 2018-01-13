using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DRS.Models
{
    public class District
    {
        public District()
        {
            this.vessels = new HashSet<Vessel>();
        }
        public int district_id { get; set; }
        [Display(Name ="Reg.District Code")]
        [Required(ErrorMessage ="Vessel Reg.District Code is Required")]
        public string district_code { get; set; }
        [Display(Name = "Reg.District Name")]
        [Required(ErrorMessage ="Vessel Reg.District Name is Required")]
        public string district_name { get; set; }
        //common data
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime district_created_date { get; set; }
        [Display(Name = "Created By")]
        public string district_created_by { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public DateTime district_last_modified_date { get; set; }
        [Display(Name = "Last Modified By")]
        public string district_last_modified_by { get; set; }
        public int district_status { get; set; }

        public virtual ICollection<Vessel> vessels { get; set; }
    }
}