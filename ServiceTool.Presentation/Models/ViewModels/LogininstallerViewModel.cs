using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTool.Presentation.Models
{
    public class LogininstallerViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string pin { get; set; }
    }
}
