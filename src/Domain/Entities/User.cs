using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User: IdentityUser
    {

        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastModified  { get; set; }


    }
}
