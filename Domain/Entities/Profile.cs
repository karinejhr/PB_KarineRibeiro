using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Profile
    {
        public int Id { get; set; }
   
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }
        [Display(Name = "Foto do Perfil")]
        public string UriImage { get; set; }

        public string UserId { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}