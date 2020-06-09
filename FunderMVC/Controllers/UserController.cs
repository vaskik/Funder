using Funder.Models;
using Funder.Options;
using Funder.Services;
using FunderMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace FunderMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {


        private readonly ILogger<UserController> _logger;
        private readonly IUserManager usrMangr;
        private readonly IProjectManager projMangr;       
        private readonly IFundManager fndMangr;
        private readonly IMediaManager medMangr;


        public UserController(ILogger<UserController> logger,
            IUserManager _usrMangr,
            IProjectManager _projMangr,
            
            IFundManager _fndMangr,
            IMediaManager _medMangr
            )
        {
            _logger = logger;
            usrMangr = _usrMangr;
            projMangr = _projMangr;
            
            fndMangr = _fndMangr;
            medMangr = _medMangr;

        }

        [HttpGet("CreateUser")]
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost("CreateUser")]
        public User PostUser([FromBody]UserOption usrOpt)
        {
            return usrMangr.CreateUser(usrOpt);
        }

        [HttpPut("{id}")]
        public User PutUser(int id, [FromBody]UserOption usrOpt)
        {
            return usrMangr.Update(usrOpt, id);
        }


        [HttpGet("LoginUser")]
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost("loginUser")]
       
        public User LoginUser([FromBody] UserOption usrOpt)
        {
            return usrMangr.FindUserByEmail(usrOpt);
        }

        //fund controller

       
        
        [HttpGet("CreateFund")]
        public IActionResult GetFund()
        {
            return View();
        }


        [HttpGet("CreateFund")]
        public IActionResult CreateFund()
        {
            return View();
        }

        [HttpPost("fund")]
        public Fund PostFund([FromBody]FundOption fndOpt)
        {
            return fndMangr.CreateFund(fndOpt);
        }

        [HttpPut("fund/{id}")]
        public Fund PutFund(int id, [FromBody]FundOption fndOpt)
        {
            return fndMangr.Update(fndOpt, id);
        }

        [HttpDelete("fund/delete/{id}")]
        public bool HardDeleteFund(int id)
        {
            return fndMangr.DeleteFundById(id);
        }

        [HttpPost("BuyFund")]
        public BackedFunds Buyfund([FromBody]FundOption fndOpt)
        {
            return fndMangr.BuyFund(fndOpt);

        }






        //media controller

        [HttpPost("media")]
        public Media PostMedia([FromBody]MediaOption medOpt)
        {
            return medMangr.CreateMedia(medOpt);
        }

        [HttpPut("media/{id}")]
        public Media PutMedia(int id, [FromBody]MediaOption medOpt)
        {
            return medMangr.Update(medOpt, id);
        }

        [HttpDelete("media/delete/{id}")]
        public bool HardDeleteMedia(int id)
        {
            return medMangr.DeleteMediaById(id);
        }
    }
}