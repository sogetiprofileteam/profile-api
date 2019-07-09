using System;

namespace sogeti_portfolio_api.Models {
    public class Education : AbstractModel {
        public School school { get; set; }
        public string levelOfDegree { get; set; }
        public string subject { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}