using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCContactListv2.Models.ViewModels
{
    public class PeopleEditVM
    {

        [Required(ErrorMessage = "You must fill in a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Invalid E-mail")]
        [Display(Name = "E-mail")]
        [EmailAddress]
        [Acme]
        public string Email { get; set; }

        public int ID { get; set; }

    }
}
