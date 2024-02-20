﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.IdentitySvr.Models
{
    public class ApplicationUser : IdentityUser
    {

        [MaxLength(200)]
        public string FirstName { get; set; }

        [MaxLength(200)]
        public string LastName { get; set; }


    }
}
