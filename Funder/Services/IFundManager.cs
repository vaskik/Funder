using Funder.Models;
using Funder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funder.Services
{
   public interface IFundManager
    {
        Fund CreateFund(FundOption fndOption);
        Fund Update(FundOption fndOption, int fundId);
        bool DeleteFundById(int id);
        BackedFunds BuyFund(FundOption fundOption);
        List<Fund> GetFunds(int projectId);

    }
}
