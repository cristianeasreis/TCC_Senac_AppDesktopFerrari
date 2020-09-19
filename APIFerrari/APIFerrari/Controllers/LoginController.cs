using APIFerrari.Models;
using FerrariEmp.lib.Modelos;
using FerrariEmp.lib.Repositorios;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIFerrari.Controllers
{
	public class LoginController : ApiController
	{

		[EnableCors(origins: "*", headers: "*", methods: "*")]

		[HttpPost]
		// POST: api/Login
		public IHttpActionResult Post([FromBody]Login login)
		{

			bool loginValido = false;

			//Verificar semo ligin veio preenchimentp e é vàlido
			if (login != null)
			{
				UsuarioRepo usuarioRepo = new UsuarioRepo();
				Usuario usuario = usuarioRepo.ConsultarPorEmail(login.Usuario);

				if (usuario != null)
				{
					if (usuario.Senha == login.Senha)
					{
						loginValido = true;
					}
					else
					{
						return Unauthorized();
					}
				}
			}
			if (loginValido == true)
			{
				//se o login for válido gerar e retorna o token
				TokenGenerado token = createToken(login.Usuario);
				return Ok(token);
			}
			else
			{
				//if usuario e senha inválido, retorna não autorizado
				return Unauthorized();
			}
		}
		private TokenGenerado createToken(string username)
		{
			//Data do Token
			DateTime issuedAt = DateTime.UtcNow;

			//Tempo de expiraçao em dias
			DateTime expires = DateTime.UtcNow.AddDays(1);

			var tokenHandler = new JwtSecurityTokenHandler();

			//cria a identidade do usuário que será concedido acesso
			ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
			{
				new Claim(ClaimTypes.Name, username.ToUpper())
			});

			const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
			var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
			var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


			//cria o token propriamente dito

			JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:61939", audience: "http://localhost:61939",
						subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);

			TokenGenerado tokenGenerado = new TokenGenerado
			{
				Username = username.ToUpper(),
				Expires = token.ValidTo,
				Token = tokenHandler.WriteToken(token)
			};

			return tokenGenerado;
		}


	}
}
