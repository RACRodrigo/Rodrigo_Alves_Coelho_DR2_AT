using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rodrigo_Alves_Coelho_DR2_AT.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
