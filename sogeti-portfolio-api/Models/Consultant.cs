using System;

namespace sogeti_portfolio_api.Models {
    public class Consultant {
        public Guid? id { get; set; }
         public string lastName { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public Status status {get;set;}
        public string phone { get; set; }
        public string title { get; set; }
        public string practice { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public CoreSkill[] coreSkills { get; set; }
        public TechnicalSkill[] technicalSkills { get; set; }
        public Education[] education { get; set; }
        public Certification[] certifications { get; set; }
        public Experience[] experience { get; set; }
    }
}