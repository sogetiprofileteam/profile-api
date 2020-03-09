using System;

namespace sogeti_portfolio_api.Models
{
   public abstract class AbstractModel
   {
      public Guid? id { get; set; }

      public string GuidString {
            get { return id.ToString(); }
            set { id = new Guid(value); }
        }
   }
}
