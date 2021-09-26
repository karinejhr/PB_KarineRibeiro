using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppChefIdentity.Models
{
    public class Profile
    {
        public int Id { get; set; }
   
        public string Nome { get; set; }
     
        public DateTime Nascimento { get; set; }
       
        public string UriImage { get; set; }

        public string UserId { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}