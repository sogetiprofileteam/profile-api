using System;

namespace sogeti_portfolio_api.Models {
    public class Education : AbstractModel {
        public School school { get; set; }
        public string levelOfDegree { get; set; }
        public string subject { get; set; }
        public int startMonth { get; set; }
        public int startYear { get; set; }
        public int endMonth { get; set; }
        public int endYear { get; set; }
    }
}