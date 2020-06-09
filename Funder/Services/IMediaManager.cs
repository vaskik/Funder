using Funder.Models;
using Funder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funder.Services
{
   public interface IMediaManager
    {
        Media CreateMedia(MediaOption medOption);
        Media Update(MediaOption medOption, int mediaId);
        bool DeleteMediaById(int id);
    }
}
