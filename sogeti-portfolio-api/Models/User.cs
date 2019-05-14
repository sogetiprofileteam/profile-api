using System;

namespace sogeti_portfolio_api.Domain {
    public class User {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
        public Preference[] Preferences { get; set; }
    }
}