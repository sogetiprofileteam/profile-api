using System;

namespace sogeti_portfolio_api.Domain {
    public class Consultant: Object {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Practice { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public CoreSkill[] CoreSkills { get; set; }
        public TechnicalSkill[] TechnicalSkills { get; set; }
        public Education[] Education { get; set; }
        public Certification[] Certifications { get; set; }
        public Experience[] Experience { get; set; }
    }
}