using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Funder.Models;
using Funder.Options;
using Funder.Repository;
using Funder.Services;
using FunderMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FunderMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectManager projMangr;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IFundManager fndMangr;
        private readonly FunderDbContext dbContext;
        public ProjectController(ILogger<ProjectController> logger,
        IProjectManager _projMangr,IWebHostEnvironment _hostingEnvironment
            ,IFundManager _fndMangr,
        FunderDbContext _dbContext

         )

        {
            dbContext = _dbContext;
            _logger = logger;

            projMangr = _projMangr;

            fndMangr = _fndMangr;

            hostingEnvironment = _hostingEnvironment;
        }

        // project controller

        [HttpGet("CreateProject")]
        public IActionResult CreateProject()
        {
            return View();
        }


        [HttpPost("CreateProject")]
        public Project PostProject([FromForm]CreateProjectOption createProjectOption)
        {
            if (createProjectOption.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(createProjectOption.MyImage.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "Media");
                var filePath = Path.Combine(uploads, uniqueFileName);
                createProjectOption.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));
                createProjectOption.ImagePath = "/Media/" + uniqueFileName;


                //to do : Save uniqueFileName  to your db table   
  
            }
            return projMangr.CreateProject(createProjectOption);
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        [HttpPut("project/{id}")]
        public Project PutProject(int id, [FromBody]ProjectOption projOpt)
        {
            return projMangr.Update(projOpt, id);
        }

        [HttpDelete("project/delete/{id}")]
        public bool HardDeleteProject(int id)
        {
            return projMangr.DeleteProjectById(id);
        }

        //[HttpGet("GetProjects/{search}")]
        //public IActionResult GetProjects([FromRoute] string search)
        //{
        //    var projects = new ProjectViewModel
        //    {
        //        Projects = projMangr.GetAllProjects().Where(p=>p.Description.Contains(search)).ToList()

        //    };
        //    return View(projects);
        //}

        //[HttpGet("GetProjects")]
        //public IActionResult GetProjects2()
        //{
        //    var projects = new ProjectViewModel
        //    {
        //        Projects = projMangr.GetAllProjects().ToList()

        //    };
        //    return View("GetProjects",projects);
        //}

        [HttpGet, Route("ProjectDetails/{projectId}")]

        public IActionResult ProjectDetails([FromRoute]int projectId)
        {

            ProjectDetailsViewModel projectDetails = new ProjectDetailsViewModel
            {

                Project = projMangr.FindProjectById(projectId),
                Funds = fndMangr.GetFunds(projectId)

            };

            return View(projectDetails);
        }

        [HttpGet("GetProjects")]
        public async Task<IActionResult> GetProjects(string projectCategory, string searchString)
        {
            //Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = from m in dbContext.Projects
                                               orderby m.ProjectCategory
                                               select m.ProjectCategory;

            //IQueryable<string> categoryQuery = dbContext.Projects
            //    .OrderBy(m => m.ProjectCategories)
            //    .Select(m => m.ProjectCategories);

            var viewallprojects = new ProjectViewModel
            {
                ProjectCategories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Projects = projMangr.SearchProjects(projectCategory, searchString).ToList()
            };
            return View(viewallprojects);
        }
    }
}