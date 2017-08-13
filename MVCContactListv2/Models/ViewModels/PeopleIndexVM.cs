using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCContactListv2.Models.ViewModels
{
    public class PeopleIndexVM
    {
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public int Id { get; set; }

        public bool ShowAsHighlighted { get; set; }

    }
}
