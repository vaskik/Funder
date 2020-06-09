using Funder.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Funder.Models;
using Funder.Options;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Funder.Services
{
    public class ProjectManagement : IProjectManager
    {
        private FunderDbContext db;

        public ProjectManagement(FunderDbContext _db)
        {
            db = _db;
        }


        //CRUD
        // create read update delete

        public Project CreateProject([FromForm]CreateProjectOption createProjectOption)
        {
            User user = db.Set<User>().Find(createProjectOption.ProjectCreatorId);
            Project project = new Project
            {
                ProjectName = createProjectOption.ProjectName,
                ProjectCreator = user,
                Description = createProjectOption.Description,
                Goal = createProjectOption.Goal,
                End = createProjectOption.End,
                Progress = createProjectOption.Progress,
                IsActive = true,
                ProjectCategory = createProjectOption.ProjectCategory,
                ImagePath = createProjectOption.ImagePath,
                Funds = new List<Fund>


                {
                    new Fund
                    {
                        Amount=createProjectOption.Amount,

                        Reward=createProjectOption.Reward

                    }


            },

                //Fund fund = new Fund { 

                //    Amount = FundOption.Amound

            };
            db.Projects.Add(project);
            db.SaveChanges();

            return project;
        }

        public Project FindProjectById(int projectId)
        {

            return db.Projects.Find(projectId);
        }


        public Project Update(ProjectOption projOption, int projectId)
        {

            Project project = db.Projects.Find(projectId);

            if (projOption.ProjectName != null)
                project.ProjectName = projOption.ProjectName;
            if (projOption.Description != null)
                project.Description = projOption.Description;
            if (projOption.Progress != null)
                project.Progress = projOption.Progress;
            if (projOption.ProjectCategory != null)
                project.ProjectCategory = projOption.ProjectCategory;
            if (projOption.Start != new DateTime())
                project.Start = projOption.Start;
            if (projOption.End != new DateTime())
                project.End = projOption.End;

            db.SaveChanges();
            return project;
        }

        public bool DeleteProjectById(int id)
        {
            Project project = db.Projects.Find(id);
            if (project != null)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Project> GetAllProjects()
        {
            return db.Projects.ToList();
        }



        public IQueryable<Project> SearchProjects(string projectCategory, string searchString)
        {
            var projects = db.Projects
                .Where(p => p.IsActive == true)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                projects = projects.Where(s => s.ProjectName.Contains(searchString));
            }

            if (!string.IsNullOrWhiteSpace(projectCategory))
            {
                projects = projects.Where(s => s.ProjectCategory.Contains(projectCategory));
            }

                if (projects == null)
            {
                return null; 
            }
            return projects;
        }
    }
}