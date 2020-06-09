using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funder.Models;
using Funder.Options;
using Funder.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FunderMVC.Controllers
{
    
    [Route("[controller]")]
    public class BackedFundsController : Controller
    {

        private readonly ILogger<BackedFundsController> _logger;
        private readonly IBackedFundsManager bfnMangr;
        private readonly IWebHostEnvironment hostingEnvironment;


        public BackedFundsController(ILogger<BackedFundsController> logger,
            IBackedFundsManager _bfnMangr, IWebHostEnvironment _hostingEnvironment

        )

        {
            _logger = logger;
            bfnMangr = _bfnMangr;
            hostingEnvironment = _hostingEnvironment;

        }



        [HttpGet("CreateBackedFunds")]
        public IActionResult CreateBackedFunds()
        {
            return View();
        }


        [HttpPost("CreateBackedFunds")]
        public BackedFunds PostBackedFunds([FromBody]BackedFundsOption bfnOpt)
        {
            return bfnMangr.CreateBackedFunds(bfnOpt);
        }

        [HttpPut("{id}")]
        public BackedFunds PutBackedFunds(int id, [FromBody]BackedFundsOption bfnOpt)
        {
            return bfnMangr.Update(bfnOpt, id);
        }

    }
}