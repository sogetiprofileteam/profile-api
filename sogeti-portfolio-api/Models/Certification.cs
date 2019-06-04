using System;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Models {
    public class Certification {
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime dateRecieved { get; set; }
    }
}