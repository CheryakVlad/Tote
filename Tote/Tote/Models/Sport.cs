using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tote.Models
{
    public class Sport
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Sport")]
        public string Name { get; set; }
    }
}