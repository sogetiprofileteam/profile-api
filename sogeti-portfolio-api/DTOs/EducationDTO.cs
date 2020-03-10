using System;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.DTOs
{
    public class EducationDTO : AbstractDTO
    {
        public string school { get; set; }
        public string levelOfDegree { get; set; }
        public string subject { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}