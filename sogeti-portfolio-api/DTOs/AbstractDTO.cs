using System;

namespace sogeti_portfolio_api.DTOs
{
    public class AbstractDTO
    {
        public Guid? id { get; set; }

      public string GuidString {
            get { return id.ToString(); }
            set { id = new Guid(value); }
        }
    }
}