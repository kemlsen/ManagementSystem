﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
    public enum UserType
    {
        User,
        Admin
    }
}
