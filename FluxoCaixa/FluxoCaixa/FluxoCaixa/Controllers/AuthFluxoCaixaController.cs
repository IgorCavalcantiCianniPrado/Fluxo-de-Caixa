using FluxoCaixa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FluxoCaixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthFluxoCaixaController : ControllerBase
    {
        private IConfiguration configuration;
        public AuthFluxoCaixaController(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Usuario login)
        {
            bool loginValido = ValidarUsuario(login);

            if(!loginValido)
                return Unauthorized();

            var tokenString = GerarTokenJWT();
            return Ok(new { token = tokenString });
        }

        private string GerarTokenJWT()
        {
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
            expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        private bool ValidarUsuario(Usuario loginRecebido)
        {
            var usuario = configuration.GetSection("Login:Usuario").Value;
            var senha = configuration.GetSection("Login:Senha").Value;

            if (loginRecebido.NomeUsuario == usuario && loginRecebido.Senha == senha)
                return true;

            return false;
        }
    }
}
