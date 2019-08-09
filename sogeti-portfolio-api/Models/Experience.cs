using System;

namespace sogeti_portfolio_api.Models {
    public class Experience {
      //  public Guid Id { get; set; }
        public string companyName { get; set; }
        public string title { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public Description[] descriptions { get; set; }
    }
}