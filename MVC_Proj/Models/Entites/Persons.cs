using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Proj.Models.Entites
{
    public class Persons
    {
        [Key]
        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ForeignKey("cities")]
        public int Address { get; set; }
        public Cities cities { get; set; }

        public int Age { get; set; }

    }
}
