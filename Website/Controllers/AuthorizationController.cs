using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Website.Models;
using Website.Repositories;

namespace Website.Controllers
{

    public class AuthorizationController : Controller
    {
        private readonly IOptions<JWTData> _jwtOptions;
        private readonly AccountRepository _accountRepository;

        public AuthorizationController(IOptions<JWTData> jwtOptions, AccountRepository accountRepository)
        {
            _jwtOptions = jwtOptions;
            _accountRepository = accountRepository;
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies["user_id"] != null) { return Ok("Вы уже авторизованы. Выйдите из аккаунта"); }
            return View();
        }

        [Route("registration")]
        [HttpGet]
        public IActionResult Registration() => View();

        [Route ("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("user_id");
            return RedirectPermanent("/");
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromForm]LoginData data)
        {
            
            var account = _accountRepository.Get(data.Login);
            if (account != null)
            {
                Response.Cookies.Append("user_id", account.Id.ToString());
                return RedirectPermanent("/");
            }
            return Unauthorized();
        }

        [Route("registration")]
        [HttpPost]
        public async Task<IActionResult> Registration([FromForm]Account data)
        {
            var account = _accountRepository.Get(data.Login);
            if(account != null)
                return BadRequest();

            await _accountRepository.Add(data);
            await _accountRepository.SaveAsync();

            account = _accountRepository.Get(data.Login);

            Response.Cookies.Append("user_id", account.Id.ToString());

            return RedirectPermanent("/");
        }
    }
}
