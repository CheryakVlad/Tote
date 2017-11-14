using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tote.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Country")]
        public string Name { get; set; }
    }
}