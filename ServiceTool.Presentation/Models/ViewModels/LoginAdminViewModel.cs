﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTool.Presentation.Models
{
    public class LoginAdminViewModel
    {
        [Required]
        public string Username{ get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
