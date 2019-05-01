using System;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Models {
    public abstract class Object: IObject {
        public abstract Guid Id { get; set; }
    }
}