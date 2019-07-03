using System;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Models {
    public class Certification : AbstractModel {
        public string name { get; set; }
        public string title { get; set; }
        public DateTime dateRecieved { get; set; }
    }
}