using Funder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funder.Options
{
    public class BackedFundsOption
    {
        public int BackedFundsId { get; set; }       
        public int FundId { get; set; }
        public int pledges { get; set; }
       
    }
}
