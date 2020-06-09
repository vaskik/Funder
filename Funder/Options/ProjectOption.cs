using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Funder.Options
{
   public class ProjectOption
    {

        public string ProjectName { get; set; }
        public string Description { get; set; }
        
        public decimal Goal { get; set; }
        
        public decimal Progress { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ProjectCategory { get; set; }

        


    }
}
