using System;
using Microsoft.AspNetCore.Identity;

namespace SS.Domain.Entities
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
