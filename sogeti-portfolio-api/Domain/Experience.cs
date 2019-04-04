using System;

namespace sogeti_portfolio_api.Domain {
    public class Experience {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Description[] Descriptions { get; set; }
    }
}