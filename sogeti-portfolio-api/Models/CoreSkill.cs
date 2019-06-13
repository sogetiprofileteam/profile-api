using System;

namespace sogeti_portfolio_api.Models {
    public class CoreSkill : AbstractModel {
        public string name { get; set; }
        public bool display { get; set; }
        public int displayOrder { get; set; }
    }
}
