using Funder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FunderMVC.Models
{
    public class ProjectViewModel
    {
        public List<Project> Projects { get; set; }
        public List<Fund> Funds { get; set; }
        public string ImagePath { get; set; }
        public string SearchString { get; set; }
        public SelectList ProjectCategories { get; set; }


        public ProjectViewModel()

        {
            Projects = new List<Project>();
            Funds = new List<Fund>();
        }

    }


}
