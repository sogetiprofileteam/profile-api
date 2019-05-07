using System;

namespace sogeti_portfolio_api.Models {
    public class Education {
        public Guid Id { get; set; }
        public string School { get; set; }
        public string LevelOfDegree { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}