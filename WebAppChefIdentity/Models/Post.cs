using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppChefIdentity.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Texto { get; set; }

        public DateTime DataCriacao { get; set; }

        public Profile Profile { get; set; }
    }
}
