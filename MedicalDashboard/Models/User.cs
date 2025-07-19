using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicalDashboard.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string ProfileImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}