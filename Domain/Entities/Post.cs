using System;
using System.ComponentModel.DataAnnotations;


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
