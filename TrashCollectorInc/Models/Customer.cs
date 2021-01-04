using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrashCollectorInc.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is a Required Input")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is a Required Input")]
        public string LastName { get; set; }


        [Display(Name = "Street Address")]
        [Required(ErrorMessage = "Street Address is a Required Input")]
        public string StreetAddress { get; set; }

        //include city in a dropdown list auto populated by state?
        [Display(Name = "City")]
        public string CityName { get; set; }

        //include in a dropdown list? 
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip Code is a Required Input")]
        public String ZipCode { get; set; }

        [Display(Name = "Primary Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Start Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime? StartPickupDate { get; set; }

        [Display(Name = "Suspend Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime? SuspendPickup { get; set; }

        [Display(Name = "Weekly Pickup Day")]
        [NotMapped]
        public IEnumerable<SelectListItem> WeeklyPickupDay { get; set; }

        [Display(Name = "One-time Pickup Request")]
        [DataType(DataType.Date)]
        public DateTime? OneTimePickupDateRequest { get; set; }

        [Display(Name = "Monthly Charge")]
        public double MonthlyCharge { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }
}
