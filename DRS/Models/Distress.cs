using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DRS.Models
{
    public class Distress
    {
        public Distress()
        {
            this.d_detail = new HashSet<DistressViewModel>();
        }
        public int distress_id { get; set; }
        [Display(Name ="Distress Name")]
        [Required(ErrorMessage ="Distress Name is Required")]
        public string distress_name { get; set; }
        [Display(Name = "Distress Description")]
        [Required(ErrorMessage = "Distress Description is Required")]
        public string distress_description { get; set; }
        //common data
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime distress_created_date { get; set; }
        [Display(Name = "Created By")]
        public string distress_created_by { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public DateTime distress_last_modified_date { get; set; }
        [Display(Name = "Last Modified By")]
        public string distress_last_modified_by { get; set; }
        public int distress_status { get; set; }

        public virtual ICollection<DistressViewModel> d_detail { get; set; }
    }
}