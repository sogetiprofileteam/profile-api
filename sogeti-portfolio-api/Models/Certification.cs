using System;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Domain {
    public class Certification: Object {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateRecieved { get; set; }
    }
}