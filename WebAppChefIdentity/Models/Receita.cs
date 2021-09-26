using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppChefIdentity.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Origem { get; set; }
        public string TempoPreparo { get; set; }
        public int NivelDificuldade { get; set; }
        public string ImagemUri { get; set; }
    }
}
