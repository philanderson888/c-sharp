﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Security;

namespace MVC_User_Login.Models
{
    public class User
    {
        [Display(Name="User ID")]
        public int UserId { get; set; }

        [Display(Name ="User Name")]
        [Required(ErrorMessage = "Username must be supplied")]
        [EmailAddress(ErrorMessage = "Username must be a valid email address")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must be supplied")]
        [StringLength(20,ErrorMessage = "Invalid Password Length.  Minimum 8 and Maximum 20 Characters")]
        [DataType(DataType.Password)]        
        [MembershipPassword(
            MinRequiredPasswordLength =8,
            MinPasswordLengthError = "Password must be minimum 8 characters and contain at least one symbol",
            MinRequiredNonAlphanumericCharacters =1,
            MinNonAlphanumericCharactersError = "Please provide at least one non-alphanumeric character",
            ErrorMessage = "Password must be minimum 8 characters and contain at least one symbol"            
            )]
        public string Password { get; set; }
    }
}