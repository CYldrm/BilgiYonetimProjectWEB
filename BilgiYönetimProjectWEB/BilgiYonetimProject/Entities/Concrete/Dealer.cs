using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Dealer : IEntity
    {
        public int DealerId { get; set; }
        public int? BrandId { get; set; } // Foreign key to Brand
        public string? DealerCity { get; set; }
        public string? DealerAddress { get; set; }
        public string? DealerPhoneNo { get; set; }
        public string? DealerCode { get; set; }
        public DateTime? DealerDate { get; set; }
    }
}
