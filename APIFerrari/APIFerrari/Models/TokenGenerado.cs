using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFerrari.Models
{
	public class TokenGenerado
	{
		public string Token { get; set; }
		public string Username { get; set; }
		public DateTime Expires { get; set; }
	}
}