using System;

namespace sogeti_portfolio_api.Models {
    public class TechnicalSkill : AbstractModel {
        public string name { get; set; }
        public bool display { get; set; }
        public int displayOrder { get; set; }
    }
}
