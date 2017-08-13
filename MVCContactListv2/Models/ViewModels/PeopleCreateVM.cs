using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCContactListv2.Models.ViewModels
{
    public class PeopleCreateVM
    {

        [Required(ErrorMessage = "You must fill in a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Invalid E-mail")]
        [Display(Name = "E-mail")]
        [EmailAddress]
        [Acme(ErrorMessage = "Your E-mail must end with acme.com")] // Egenskrivet valideringsattribut
        public string Email { get; set; }


        [Display(Name = "What is 2 + 2?")]
        [Range(4, 4, ErrorMessage = "Stop Roboting, Start Humaning")]
        public int BotCheck { get; set; }

    }
}
