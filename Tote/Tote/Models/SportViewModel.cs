using System.ComponentModel.DataAnnotations;

namespace Tote.Models
{
    public class SportViewModel
    {
        [Required]
        public int SportId { get; set; }
        [Required]
        [Display(Name ="Sport")]
        public string Name { get; set; }
    }
}