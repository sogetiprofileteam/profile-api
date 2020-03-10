namespace sogeti_portfolio_api.DTOs
{
    public class TechnicalSkillDTO : AbstractDTO
    {
        public string name { get; set; }
        public bool display { get; set; }
        public int displayOrder { get; set; }
    }
}