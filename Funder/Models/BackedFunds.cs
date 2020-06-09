using System;
using System.Collections.Generic;
using System.Text;

namespace Funder.Models
{
   public class BackedFunds
    {
        public int BackedFundsId { get; set; }
        public int UserId { get; set; }
       // public User User { get; set; }
        public int FundId { get; set; }
        public Fund Fund { get; set; }
        public DateTimeOffset DateBacked{ get; set; }

        public BackedFunds()
        {
            DateBacked = DateTimeOffset.Now;

        }
    }
}
