using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationsBlog.Models
{
    public class UserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public bool IsInRole { get; set; }
        public bool HasUser { get; set; }
    }
}
