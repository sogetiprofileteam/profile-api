using System;

namespace sogeti_portfolio_api.Models {
    public class TechnicalSkill {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Display { get; set; }
        public int DisplayOrder { get; set; }
    }
}