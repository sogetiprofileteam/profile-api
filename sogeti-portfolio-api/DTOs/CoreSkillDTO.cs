namespace sogeti_portfolio_api.DTOs
{
    public class CoreSkillDTO : AbstractDTO
    {
        public string name { get; set; }
        public bool display { get; set; }
        public int displayOrder { get; set; }
    }
}