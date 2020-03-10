using System;

namespace sogeti_portfolio_api.DTOs
{
    public class CertificationDTO : AbstractDTO
    {
        public string name { get; set; }
        public string title { get; set; }
        public DateTime dateRecieved { get; set; }
    }
}