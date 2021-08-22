using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationsBlog.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
