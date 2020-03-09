using System;

namespace sogeti_portfolio_api.Models {
    public class User : AbstractModel{
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
        public bool[] Permissions { get; set; } 
        public Preference[] Preferences { get; set; }
    }
}