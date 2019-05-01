using System;

namespace sogeti_portfolio_api.Domain {
    public class TechnicalSkill : Object {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Display { get; set; }
        public int DisplayOrder { get; set; }
    }
}