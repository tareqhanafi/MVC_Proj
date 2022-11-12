using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Proj.Models.Entites
{

    
    public class Cities
    {
        [Key]
        [Display(Name = "City Number")]
        public int CityID { get; set; }

        [Display(Name = "City Name")]
        public string Name { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime createdDate { get; set; }

        public ICollection<Persons> Persons { get; set; }
    }
}
