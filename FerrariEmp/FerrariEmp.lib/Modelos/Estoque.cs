using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerrariEmp.lib.Modelos
{
    public class Estoque
    {
        public int Id { get; set; }
        public string Peca { get; set; }
        public string Quantidade { get; set; }
        public decimal Valor { get; set; }

    }
}
