using System;
using System.Collections.Generic;
using System.Text;

namespace Funder.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public  ICollection<Project> Projects { get; set; }
        //public virtual ICollection<Fund> Funds { get; set; }
        public User()
        {
            Dob = DateTime.Now;

        }
    }
}