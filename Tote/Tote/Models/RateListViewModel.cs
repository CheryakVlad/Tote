using System;
using System.ComponentModel.DataAnnotations;

namespace Tote.Models
{
    public class RateListViewModel
    {
        [Display(Name = "Number")]
        public int RateId { get; set; }
        [Display(Name = "Сoefficient for winning the home team")]
        public double WinCommandHome { get; set; }
        [Display(Name = "Сoefficient for winning the guest team")]
        public double WinCommandGuest { get; set; }
        [Display(Name = "Сoefficient for a draw")]
        public double Draw { get; set; }
        public int MatchId { get; set; }
        public string CommandHome { get; set; }
        public string CommandGuest { get; set; }
        public DateTime Date { get; set; }
    }
}