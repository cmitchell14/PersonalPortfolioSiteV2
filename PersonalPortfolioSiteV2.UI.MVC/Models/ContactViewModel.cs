using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PersonalPortfolioSiteV2.UI.MVC.Models
{
    public class ContactViewModel
    {
        //Props
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is a required field.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter your message here.")]
        [UIHint("MultilineText")]
        public string Body { get; set; }
    }
}