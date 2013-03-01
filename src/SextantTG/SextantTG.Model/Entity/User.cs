using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Model.Entity
{
    public class User
    {
        public string UserId { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public int? Status { get; set; }
        public List<Permission> Permissions { get; set; }
        public List<Favorite> Facorites { get; set; }
    }
}
