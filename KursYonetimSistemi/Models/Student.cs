using System;
using System.Collections.Generic;

namespace KursYonetimSistemi.Models
{
    public class Student
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Tc { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Guardian { get; set; }
        public string Notes { get; set; }
        public List<string> Courses { get; set; } = new List<string>();
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
    }
}
