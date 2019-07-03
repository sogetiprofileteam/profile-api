using System;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Data
{
    public class CreateConsultant
    {
        public CreateConsultant() {
        }

        public CoreSkill MockCoreSkill () {
            CoreSkill coreSkill = new CoreSkill ();
            return coreSkill;
        }

        public Address MockAddress () {
            Address address = new Address ();
            address.lineOne = "10900 Stonelake Blvd";
            address.lineTwo = "Suite 195";
            address.city = "Austin";
            address.state = "TX";
            address.zipCode = 78759;
            return address;
        }

        public Consultant MockConsultant () {
            Consultant consultant = new Consultant ();
            consultant.lastName = "Hsiao";
            consultant.firstName = "Lin";
            consultant.secondName = "S";
            consultant.phone = "(555) 555-5555";
            consultant.fax = "(555) 555-5555";
            consultant.email = "lin.hsiao@us.sogeti.com";
            consultant.practice = "Application & Cloud Technologies";
            consultant.title = "Consultant";
            consultant.address = MockAddress ();
            consultant.summary = "Summary";
            consultant.coreSkills = new CoreSkill[3];
            consultant.coreSkills[0] = new CoreSkill ();
            consultant.coreSkills[0].name = "Teamwork";
            consultant.coreSkills[1] = new CoreSkill ();
            consultant.coreSkills[1].name = "Leadership";
            consultant.coreSkills[2] = new CoreSkill ();
            consultant.coreSkills[2].name = "Communication";
            consultant.technicalSkills = new TechnicalSkill[3];
            consultant.technicalSkills[0] = new TechnicalSkill();
            consultant.technicalSkills[0].name = "Angular";
            consultant.technicalSkills[1] = new TechnicalSkill();
            consultant.technicalSkills[1].name = ".NET Core";
            consultant.technicalSkills[2] = new TechnicalSkill();
            consultant.technicalSkills[2].name = "Prolog";
            consultant.education = new Education[2];
            consultant.education[0] = new Education();
            consultant.education[0].levelOfDegree = "Bachelor of Science";
            consultant.education[0].school.name = "University of North Carolina at Asheville";
            consultant.education[0].subject = "Computer Science";
            consultant.education[0].startDate = new DateTime(2012, 08, 01);
            consultant.education[0].endDate = new DateTime(2016, 05, 01);

            consultant.education[1] = new Education();
            consultant.education[1].levelOfDegree = "Master of Science";
            consultant.education[1].school.name = "University of Texas at Austin";
            consultant.education[1].subject = "Computer Science";
            consultant.education[1].startDate = new DateTime(2016, 08, 01);
            consultant.education[1].endDate = new DateTime(2018, 05, 01);

            consultant.certifications = new Certification[2];
            consultant.certifications[0] = new Certification();
            consultant.certifications[0].name = "AWS Engineer 1";
            consultant.certifications[0].title = "Solutions Architect";
            consultant.certifications[0].dateRecieved = new DateTime(2017, 03, 01);

            consultant.certifications[1] = new Certification();
            consultant.certifications[1].name = "AWS Engineer 1";
            consultant.certifications[0].title = "Solutions Architect";

            consultant.certifications[1].dateRecieved = new DateTime(2017, 03, 01);

            consultant.experience = new Experience[2];
            consultant.experience[0] = new Experience();
            consultant.experience[0].title = "Software Engineer - Entry Level";
            consultant.experience[0].startDate = new DateTime(2020, 05, 01);
            consultant.experience[0].companyName = "Small Company";
            consultant.experience[0].endDate = new DateTime(2021, 05, 01);
            consultant.experience[0].descriptions = new Description[4];
            consultant.experience[0].descriptions[0] = new Description();
            consultant.experience[0].descriptions[1] = new Description();
            consultant.experience[0].descriptions[2] = new Description();
            consultant.experience[0].descriptions[3] = new Description();
            consultant.experience[0].descriptions[0].summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ultrices felis id molestie fringilla. Integer pulvinar tempor sapien, id ultricies purus pretium sed. Suspendisse vel justo pulvinar, scelerisque felis non, bibendum ligula.";
            consultant.experience[0].descriptions[1].summary = "Cras luctus dui sit amet dolor aliquam bibendum. Suspendisse facilisis est non sem tempus auctor.";
            consultant.experience[0].descriptions[2].summary = "Curabitur ut imperdiet nisi. Suspendisse potenti. Donec id ligula consequat, tincidunt sem nec, commodo erat. Vestibulum commodo magna quis metus commodo viverra.";
            consultant.experience[0].descriptions[3].summary = "Donec aliquet convallis urna, eget pharetra quam placerat ac. Donec et odio et tortor lobortis congue.";


            consultant.experience[1] = new Experience();
            consultant.experience[1].title = "Time Traveling Software Engineer";
            consultant.experience[1].startDate = new DateTime(2022, 05, 01);
            consultant.experience[1].companyName = "Bigger Company";
            consultant.experience[1].endDate = new DateTime(2024, 05, 01);
            consultant.experience[1].descriptions = new Description[5];
            consultant.experience[1].descriptions[0] = new Description();
            consultant.experience[1].descriptions[1] = new Description();
            consultant.experience[1].descriptions[2] = new Description();
            consultant.experience[1].descriptions[3] = new Description();
            consultant.experience[1].descriptions[4] = new Description();
            consultant.experience[1].descriptions[0].summary = "Curabitur elit ligula, porttitor eu accumsan maximus, suscipit vel ante. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed quam nulla, ullamcorper eu efficitur vitae, vulputate in ligula.";
            consultant.experience[1].descriptions[1].summary = "Vivamus vel felis in risus suscipit aliquam sed eu sem. Aliquam porta odio turpis, eget egestas sem rutrum vel. Aliquam vehicula commodo posuere.";
            consultant.experience[1].descriptions[2].summary = "Nulla eu dapibus tortor, nec vulputate augue. Vestibulum blandit enim pulvinar massa suscipit ullamcorper sed eget lectus. Morbi placerat risus vitae lorem egestas aliquet.";
            consultant.experience[1].descriptions[3].summary = "Maecenas auctor ex eget pretium dictum. Morbi vel dolor erat. In quis vulputate metus.";
            consultant.experience[1].descriptions[4].summary = "Aenean placerat placerat est eget eleifend.";
            return consultant;
        }

    }
}