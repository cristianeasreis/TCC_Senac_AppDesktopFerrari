using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerrariEmp.lib.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string N { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataStatus { get; set; }


    }
}
