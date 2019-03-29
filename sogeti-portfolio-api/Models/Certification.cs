using System;

namespace sogeti_portfolio_api.Models {
    public class Certification {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateRecieved { get; set; }
    }
}