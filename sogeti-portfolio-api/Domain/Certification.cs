using System;

namespace sogeti_portfolio_api.Domain {
    public class Certification {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateRecieved { get; set; }
    }
}