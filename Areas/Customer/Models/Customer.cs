using System;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Areas.Customer.Models
{
    public class Customer
    {
        [Key]
        public int Pid { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }

        public string AvatarUrl { get; set; }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public string Address { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string Province { get; set; }

        public string LinkFaceBook { get; set; } 
        public string Zalo { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public string ActivationCode { get; set; }
        public bool Deleted { get; set; } = false;
        public bool Enabled { get; set; } = false;

        public string GoogleId { get; set; }
        public string FacebookId { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
