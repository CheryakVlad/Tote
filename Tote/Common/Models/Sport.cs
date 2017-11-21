using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Sport
    {
        [Required]
        public int SportId { get; set; }
        [Required]
        [Display(Name = "Sport")]
        public string Name { get; set; }
    }
}
