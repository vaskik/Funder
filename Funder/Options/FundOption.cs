using Funder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Funder.Options
{
   public class FundOption
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
       
        public DateTime FundDate { get; set; }
        public string Reward { get; set; }

        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int FundId { get; set; }

        public Project Project { get; set; }
    }
}
