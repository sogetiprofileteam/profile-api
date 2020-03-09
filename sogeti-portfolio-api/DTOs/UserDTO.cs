using System;

namespace sogeti_portfolio_api.DTOs
{
    public class UserDTO : AbstractDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
    }
}