using System;
using sogeti_portfolio_api.Domain;

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
            address.LineOne = "10900 Stonelake Blvd";
            address.LineTwo = "Suite 195";
            address.City = "Austin";
            address.State = "TX";
            address.ZipCode = 78759;
            return address;
        }

        public Consultant MockConsultant () {
            Consultant consultant = new Consultant ();
            consultant.LastName = "Hsiao";
            consultant.FirstName = "Lin";
            consultant.SecondName = "S";
            consultant.Phone = "(555) 555-5555";
            consultant.Fax = "(555) 555-5555";
            consultant.Email = "lin.hsiao@us.sogeti.com";
            consultant.Practice = "Application & Cloud Technologies";
            consultant.Title = "Consultant";
            consultant.Address = MockAddress ();
            consultant.CoreSkills = new CoreSkill[3];
            consultant.CoreSkills[0] = new CoreSkill ();
            consultant.CoreSkills[0].Name = "Teamwork";
            consultant.CoreSkills[1] = new CoreSkill ();
            consultant.CoreSkills[1].Name = "Leadership";
            consultant.CoreSkills[2] = new CoreSkill ();
            consultant.CoreSkills[2].Name = "Communication";
            consultant.TechnicalSkills = new TechnicalSkill[3];
            consultant.TechnicalSkills[0] = new TechnicalSkill();
            consultant.TechnicalSkills[0].Name = "Angular";
            consultant.TechnicalSkills[1] = new TechnicalSkill();
            consultant.TechnicalSkills[1].Name = ".NET Core";
            consultant.TechnicalSkills[2] = new TechnicalSkill();
            consultant.TechnicalSkills[2].Name = "Prolog";
            consultant.Education = new Education[2];
            consultant.Education[0] = new Education();
            consultant.Education[0].LevelOfDegree = "Bachelor of Science";
            consultant.Education[0].School = "University of North Carolina at Asheville";
            consultant.Education[0].Subject = "Computer Science";
            consultant.Education[0].StartDate = new DateTime(2012, 08, 01);
            consultant.Education[0].EndDate = new DateTime(2016, 05, 01);

            consultant.Education[1] = new Education();
            consultant.Education[1].LevelOfDegree = "Master of Science";
            consultant.Education[1].School = "University of Texas at Austin";
            consultant.Education[1].Subject = "Computer Science";
            consultant.Education[1].StartDate = new DateTime(2016, 08, 01);
            consultant.Education[1].EndDate = new DateTime(2018, 05, 01);

            consultant.Certifications = new Certification[2];
            consultant.Certifications[0] = new Certification();
            consultant.Certifications[0].Name = "AWS Engineer 1";
            consultant.Certifications[0].DateRecieved = new DateTime(2017, 03, 01);

            consultant.Certifications[1] = new Certification();
            consultant.Certifications[1].Name = "AWS Engineer 1";
            consultant.Certifications[1].DateRecieved = new DateTime(2017, 03, 01);

            consultant.Experience = new Experience[2];
            consultant.Experience[0] = new Experience();
            consultant.Experience[0].Title = "Software Engineer - Entry Level";
            consultant.Experience[0].StartDate = new DateTime(2020, 05, 01);
            consultant.Experience[0].CompanyName = "Small Company";
            consultant.Experience[0].EndDate = new DateTime(2021, 05, 01);
            consultant.Experience[0].Descriptions = new Description[4];
            consultant.Experience[0].Descriptions[0] = new Description();
            consultant.Experience[0].Descriptions[1] = new Description();
            consultant.Experience[0].Descriptions[2] = new Description();
            consultant.Experience[0].Descriptions[3] = new Description();
            consultant.Experience[0].Descriptions[0].Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ultrices felis id molestie fringilla. Integer pulvinar tempor sapien, id ultricies purus pretium sed. Suspendisse vel justo pulvinar, scelerisque felis non, bibendum ligula.";
            consultant.Experience[0].Descriptions[1].Summary = "Cras luctus dui sit amet dolor aliquam bibendum. Suspendisse facilisis est non sem tempus auctor.";
            consultant.Experience[0].Descriptions[2].Summary = "Curabitur ut imperdiet nisi. Suspendisse potenti. Donec id ligula consequat, tincidunt sem nec, commodo erat. Vestibulum commodo magna quis metus commodo viverra.";
            consultant.Experience[0].Descriptions[3].Summary = "Donec aliquet convallis urna, eget pharetra quam placerat ac. Donec et odio et tortor lobortis congue.";


            consultant.Experience[1] = new Experience();
            consultant.Experience[1].Title = "Time Traveling Software Engineer";
            consultant.Experience[1].StartDate = new DateTime(2022, 05, 01);
            consultant.Experience[1].CompanyName = "Bigger Company";
            consultant.Experience[1].EndDate = new DateTime(2024, 05, 01);
            consultant.Experience[1].Descriptions = new Description[5];
            consultant.Experience[1].Descriptions[0] = new Description();
            consultant.Experience[1].Descriptions[1] = new Description();
            consultant.Experience[1].Descriptions[2] = new Description();
            consultant.Experience[1].Descriptions[3] = new Description();
            consultant.Experience[1].Descriptions[4] = new Description();
            consultant.Experience[1].Descriptions[0].Summary = "Curabitur elit ligula, porttitor eu accumsan maximus, suscipit vel ante. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed quam nulla, ullamcorper eu efficitur vitae, vulputate in ligula.";
            consultant.Experience[1].Descriptions[1].Summary = "Vivamus vel felis in risus suscipit aliquam sed eu sem. Aliquam porta odio turpis, eget egestas sem rutrum vel. Aliquam vehicula commodo posuere.";
            consultant.Experience[1].Descriptions[2].Summary = "Nulla eu dapibus tortor, nec vulputate augue. Vestibulum blandit enim pulvinar massa suscipit ullamcorper sed eget lectus. Morbi placerat risus vitae lorem egestas aliquet.";
            consultant.Experience[1].Descriptions[3].Summary = "Maecenas auctor ex eget pretium dictum. Morbi vel dolor erat. In quis vulputate metus.";
            consultant.Experience[1].Descriptions[4].Summary = "Aenean placerat placerat est eget eleifend.";
            return consultant;
        }

    }
}