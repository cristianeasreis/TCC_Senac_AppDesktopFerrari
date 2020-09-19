using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerrariEmp.lib.Modelos
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Visita { get; set; }
        public string DServiço { get; set; }
        public string DsMaquina { get; set; }
        public string Mmaquina { get; set; }
        public int IdUsuario { get; set; }
        public decimal VlServiço { get; set; }
        public DateTime DTServico { get; set; }
        public bool Ativo { get; set; }
        public DateTime DateStatus { get; set; }
 

    }
}
  
