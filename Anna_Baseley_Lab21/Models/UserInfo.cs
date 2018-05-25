using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Anna_Baseley_Lab21.Models
{
    public class UserInfo
    {
        [Required]
        [RegularExpression(@"^[A-Z{1}]+[a-zA-z{1,30}]+$", ErrorMessage = "Please enter a valid name.")]
        public string FirstName { set; get; }

        [Required]
        [RegularExpression(@"^[A-Z{1}]+[a-zA-z{1,30}]+$", ErrorMessage ="Please enter a valid name.")]
        public string LastName { set; get; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9{5,30}]+@[a-zA-A0-9{5,10}]+\.[a-zA-Z0-9{2,3}]+$", ErrorMessage = "Incorrect E-mail Format!")]
        public string Email { set; get; }

        [Required]
        [RegularExpression(@"^\d{10}$|^\d{3}\-\d{3}\-\d{4}$|^\d{3}\.\d{3}\.\d{4}$", ErrorMessage = "Please enter a valid number!")]
        public string PhoneNumber { set; get; }

        [Required]
        public string Password { set; get; }
        public UserInfo()
        {

        }
        public UserInfo(string firstName, string lastName, string email, string phoneNumber,string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;           
        }
    }
}