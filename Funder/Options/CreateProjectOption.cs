using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Funder.Options
{
   public class CreateProjectOption
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        
        public DateTime FundDate { get; set; }
        public string Reward { get; set; }

        public string ProjectName { get; set; }
        public string Description { get; set; }

        public decimal Goal { get; set; }

        public decimal Progress { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ProjectCategory { get; set; }

        public int ProjectCreatorId { get; set; }
        public IFormFile MyImage { set; get; }
        public string ImagePath { set; get; }
    }
}
