using Funder.Models;
using Funder.Options;
using Funder.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funder.Services
{
    public class BackedFundsManagement : IBackedFundsManager
    {
        private FunderDbContext db;

        public BackedFundsManagement(FunderDbContext _db)
        {
            db = _db;
        }


        //CRUD
        // create read update delete
        public BackedFunds CreateBackedFunds(BackedFundsOption bfnOption)
        {
            BackedFunds BackedFunds = new BackedFunds
            {
                BackedFundsId = bfnOption.BackedFundsId,
                //UserId = bfnOption.UserId,
               // User = bfnOption.User,
                FundId = bfnOption.FundId,
                //Fund = bfnOption.Fund,
                //DateBacked = bfnOption.DateBacked
               

            };


            db.BackedFunds.Add(BackedFunds);
            db.SaveChanges();

            return BackedFunds;
        }


        public BackedFunds Update(BackedFundsOption bfnOption, int BackedFundsId)
        {

            BackedFunds BackedFunds = db.BackedFunds.Find(BackedFundsId);

            //if (bfnOption.BackedFundsId != null)
            //    BackedFunds.BackedFundsId = bfnOption.BackedFundsId;

            //if (bfnOption.UserId != null)
            //    BackedFunds.UserId = bfnOption.UserId;

            //if (bfnOption.User != null)
            //    BackedFunds.User = bfnOption.User;

            //if (bfnOption.FundId != null)
            //    BackedFunds.FundId = bfnOption.FundId;

           // if (bfnOption.Fund != null)
               // BackedFunds.Fund = bfnOption.Fund;

            if (BackedFunds.DateBacked != new DateTime())
                BackedFunds.DateBacked = BackedFunds.DateBacked;






            db.SaveChanges();
            return BackedFunds;
        }

    }
}
