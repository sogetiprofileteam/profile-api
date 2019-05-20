using System;

namespace sogeti_portfolio_api.Models {
    public class Experience {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Description[] Descriptions { get; set; }
    }
}