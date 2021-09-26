using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Receita
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Origem { get; set; }
        [Display(Name = "Tempo de Preparo")]
        public string TempoPreparo { get; set; }
        [Display(Name = "Nível de Dificuldade")]
        public int NivelDificuldade { get; set; }
        [Display(Name = "Foto da Receita")]
        public string ImagemUri { get; set; }
    }
}
