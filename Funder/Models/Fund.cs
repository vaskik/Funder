using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Funder.Models
{
    public class Fund
    {
        public int FundId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }       
        public DateTime FundDate { get; set; }
        public string Reward { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }

        public  ICollection<BackedFunds> BackedFunds { get; set; }
        public Fund()
        {
            FundDate = DateTime.Now;
        }
    }
}
