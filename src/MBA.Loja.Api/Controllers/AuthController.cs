using MBA.Loja.Api.Extensions;
using MBA.Loja.Api.ViewModels;
using MBA.Loja.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;


namespace MBA.Loja.Api.Controllers
{
    [Route("api")]
    [Authorize]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(
             SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, 
            INotificador notificador,
            IOptions<AppSettings> appSettings) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous] 
        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel regiterUser)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var user = new IdentityUser
            {
                UserName = regiterUser.Email,
                Email = regiterUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, regiterUser.Password);
             
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return CustomResponse(HttpStatusCode.Created, GerarJWT(regiterUser.Email));
            }

            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(HttpStatusCode.Created, regiterUser);
        }

        [AllowAnonymous]
        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoguinUserViewModel userLogin)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var resul = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);
            if (resul.Succeeded)
            {
                return CustomResponse(HttpStatusCode.Accepted, GerarJWT(userLogin.Email));
            }

            if (resul.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado devido a múltiplas tentativas inválidas de acesso.");
            }

            NotificarErro("Usuario ou senha incorretos");
            return CustomResponse(HttpStatusCode.Unauthorized, userLogin);
        }
        private string GerarJWT(string? email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,             
                Audience = _appSettings.ValidoEm,          
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
