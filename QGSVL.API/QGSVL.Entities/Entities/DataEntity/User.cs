using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace QGSVL.EntityLayer.Entities.DataEntity
{
    public class user : IdentityUser
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
