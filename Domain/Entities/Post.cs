using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Texto { get; set; }
        [Display(Name = "Criado em")]
        public DateTime DataCriacao { get; set; }
        [Display(Name = "Criado por")]
        public Profile Profile { get; set; }
    }
}
