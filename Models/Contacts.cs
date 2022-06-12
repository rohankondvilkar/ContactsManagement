using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManagement.Models
{
    public class Contacts
    {
        [Display(Name="Id")]
        public Int64 Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone No is required")]
        public string PhoneNo { get; set; }
    }
}
