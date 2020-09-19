using FerrariEmp.lib.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerrariEmp
{
	
	public class Aplicacao
	{
		public static Usuario UsuarioLogado { get; set; }
		public static Usuario IDUsuario { get; set; }
      
		public static bool TestarConexao()
		{
			string connectioString = lib.Repositorios.Conexao.ConsultarConexao();

			SqlConnection conexao = new SqlConnection(connectioString);

			try
			{
				conexao.Open();
				conexao.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
