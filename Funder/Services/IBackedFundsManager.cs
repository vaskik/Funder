using Funder.Models;
using Funder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funder.Services
{
  public interface IBackedFundsManager
    {
        BackedFunds CreateBackedFunds(BackedFundsOption bfnOption);
        BackedFunds Update(BackedFundsOption BackedFundsOption, int bfnOption);


    }
}
