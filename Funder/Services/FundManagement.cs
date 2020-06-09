using Funder.Models;
using Funder.Options;
using Funder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Funder.Services
{
    public class FundManagement : IFundManager
    {
        private FunderDbContext db;
        private readonly IProjectManager projectMangr;
        private readonly IUserManager userManager;
        public FundManagement(
            FunderDbContext _db,IProjectManager _projectMangr,
            IUserManager _userManager
            )
        {
            db = _db;
            projectMangr = _projectMangr;
            userManager = _userManager;
        }


        //CRUD
        // create read update delete
        public Fund CreateFund(FundOption fndOption)
        {
            Fund fund = new Fund
            {
                Amount = fndOption.Amount,
                FundDate = fndOption.FundDate,
            };


            db.Funds.Add(fund);
            db.SaveChanges();

            return fund;
        }


        public Fund Update(FundOption fndOption, int fundId)
        {

            Fund fund = db.Funds.Find(fundId);

            if (fndOption.Amount != null)
                fund.Amount = fndOption.Amount;
            if (fndOption.FundDate != new DateTime())
                fund.FundDate = fndOption.FundDate;

            db.SaveChanges();
            return fund;
        }

        public bool DeleteFundById(int id)
        {
            Fund fund = db.Funds.Find(id);
            if (fund != null)
            {
                db.Funds.Remove(fund);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //public BackedFunds BuyFund(int fundId,int projectId,int userId)
        public BackedFunds BuyFund(FundOption fundOption)
        {
          var project = projectMangr.FindProjectById(fundOption.ProjectId);
            var fund = db.Funds
                  .Where(f => f.FundId == fundOption.FundId)
                  .SingleOrDefault();
          var backedFund = new BackedFunds()
          
            {
                //UserId=userManager.FindUserByEmail(fundOption.UserId),
                UserId = fundOption.UserId,
                FundId =fundOption.FundId
            };

            project.Progress += fund.Amount;
            db.BackedFunds.Add(backedFund);
            db.Projects.Update(project);
            db.SaveChanges();

            return backedFund;
        }



        public List<Fund> GetFunds(int projectId)
        {
            return db.Funds
                .Where(p => p.Project.ProjectId == projectId)
                .ToList();
        }
    }
}
